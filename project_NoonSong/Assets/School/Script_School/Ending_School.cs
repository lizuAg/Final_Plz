using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending_School : MonoBehaviour
{
    GameObject scanObject;
    public GameManager manager;
    bool bus,elev;
    int random;

    private void Update(){

        //1. 떡집 엔딩 입력 - 해당없음
    
        //2. 버스 엔딩 입력
        if(bus && Input.GetKeyDown(KeyCode.Z)){
            random = Random.Range(0,100);
            if (random == 0){
                manager.talkText.text = "엔딩) 100분의 1의 확률로 버스타고 등교 성공";
                //순간이동
                
            }
            else{
                manager.talkText.text= "엔딩) [눈송]은 학교까지 가는 버스를 눈앞에서 놓치고 말았다! 다음 버스는 30분 뒤...!!";
            }
        }

        //5. 엘베 엔딩 입력
        if(elev && Input.GetKeyDown(KeyCode.Z)){
            
            //5-1) 만원 아이템 있으면 if
            //5-2) 만원 아이템 없으면 else로 수정
            manager.talkText.text = "엔딩) [눈송]은 가까스로 엘레베이터에 도착했으나, 사람이 너무 많아 타야할 엘레베이터를 놓치고 말았다! 엘레베이터를 타려면 만원 아이템을 가져와라!";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //1, 떡집 엔딩
        if(collision.gameObject.name == "Store3"){
            manager.talkText.text = "엔딩) [눈송]은 떡 냄새에 홀렸다..! 떡의 유혹으로 인해 [눈송]은 등교할 의지를 잃었다..";
        }

        //2. 버스 기다리는 엔딩 + 입력: update()함수, bool 변수 bus
        if(collision.gameObject.name == "Busstop"){
            bus=true;
            manager.talkText.text = "버스를 기다리시겠습니까? 기다리려면 z키를 눌러주세요.";
        }

        //3-1(바나나) , 3-2(돌), 트랩엔딩
        if(collision.gameObject.name == "Banana"){
            manager.talkText.text = "엔딩) [눈송]은 바나나를 밟아 언덕에서 데굴데굴 굴렀다! 다리를 다쳐 학교에 가지 못한다!";
        }
        
        if(collision.gameObject.name == "Stone"){
            manager.talkText.text = "엔딩) [눈송]은 돌에 걸려 데굴데굴 굴렀다!";
        }

        //4. 라옥화 엔딩 
        if(collision.gameObject.name == "Store2"){
            manager.talkText.text = "엔딩) [눈송]의 말 걸기! \"쪼꼬야 이름이 뭐야?\" \"...아무 대답없는 쪼꼬..\" 대답없는 쪼꼬를 바라보며 눈송은 자리에 머물렀다.  ";
        }

        //5, 만원엘베 - (10000원 아이템 있으면 통과, 없으면 가져오라고..) , bool 변수 elev
        
        if(collision.gameObject.name == "Elevator"){
           elev = true;
               manager.talkText.text = "엘레베이터를 탑승해 강의실로 이동하려면 z키를 눌러주세요.";
        }

        


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //2. 버스
        if(collision.gameObject.name == "Busstop"){
            bus=false;
            manager.talkText.text = "아~아쉽다 버스타면 빨리 학교에 도착할 수 있는데~";
        }

        //5. 만원엘베
        if(collision.gameObject.name == "Elevator"){
            elev = false;
            manager.talkText.text = "강의실에 가는 방법은 엘레베이터 뿐인데?!";
        }
    }
}
