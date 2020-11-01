using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImg : MonoBehaviour
{
    public int EndingNumber=0;
    public Sprite 지하철의자;
    public Sprite 지하철인파;
    public Sprite 교수;
    public Sprite 교통사고;
    public Sprite 바나나;
    public Sprite 배탈;
    public Sprite 벚꽃엔딩;
    public Sprite 부자;
    public Sprite 비둘기;
    public Sprite 사다리;
    public Sprite 코로나사이버;
    public Sprite 킥보드;
    public Sprite 팀플;
    public Sprite 푸들;
    public Sprite 피시방;
    public Sprite 휴강;

    public void Change()
    {
        if(EndingNumber == 5)
            gameObject.GetComponent<Image>().sprite = 지하철의자;
        else if(EndingNumber == 6)
            gameObject.GetComponent<Image>().sprite = 지하철인파;
    }
}
