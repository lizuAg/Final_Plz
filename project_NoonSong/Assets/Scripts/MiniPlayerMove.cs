using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPlayerMove : MonoBehaviour
{
    /*
    게임 시작전 3, 2, 1 카운트다운
    게임 사운드 찾기 (배경사운드, 아이템 먹을때 사운드, 시작과 끝 사운드)

    플레이어 이동 스크립트
    1. 처음 속도 = 6
    2. 방향키 누름 = 순간이동으로 3칸 왔다갔다 이동 (좌표+a 이런식으로 바로바로 이동하도록), 3줄로 제한 
    3. 카메라 추적
    4. 아이템 바나나 = 멈춤...(?)
    5. 발판 = 속도증가 
    6. 공 = 진행 막힘.. + 속도 감소 

    */

    float startPos;
    bool upDown;
    public float movespeed = 12f;
    public Rigidbody2D rigid;
    public GameObject Teacher;
    


    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        startPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        rigid.MovePosition(transform.position + transform.right * Time.deltaTime * movespeed);
        if(Input.GetKeyDown(KeyCode.UpArrow) ){
            
            transform.Translate(Vector2.up);
            upDown = true;
            
            
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)){
           
            transform.Translate(Vector2.down);  
            upDown = false;
             
            
        }

        
    }


    void OnTriggerEnter2D(Collider2D collision){
        //1. 바나나 밟음
        if(collision.CompareTag("Banana"))
        {
            movespeed -= 0.5f;
            Debug.Log("바나나 밟음");
        }

        //2. 가속도 밟음
        else if(collision.CompareTag("Speedup")){
            movespeed += 1f;
            Debug.Log("스피드업");
        }

        else if(collision.CompareTag("Platform")){
            
            Debug.Log("플랫폼 부딪힘 -  팝업띄우기");

            if(upDown){
                transform.Translate(Vector2.down);
            }
            else if(!upDown){
                transform.Translate(Vector2.up);
            }

            
        }

        // 게임 종료 
        else if(collision.gameObject.name == "EndLine"){
            movespeed = 0f;
            Debug.Log("게임 종료화면, 학생 승");
            Teacher.SetActive(false); //교수 사라지기
        }
    }

    

}
