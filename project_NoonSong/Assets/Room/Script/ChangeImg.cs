using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImg : MonoBehaviour
{
    public int EndingNumber=0;
    public Sprite 지하철의자;
    public Sprite 지하철인파;
    public Sprite 지하철꼰대;
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
    public Sprite 버블티;
    public Sprite 돌부리;
    public Sprite 횡단보도;

    public void Change()
    {
        if (EndingNumber == 2)
            gameObject.GetComponent<Image>().sprite = 돌부리;
        else if (EndingNumber == 3)
            gameObject.GetComponent<Image>().sprite = 바나나;

        else if (EndingNumber == 5)
            gameObject.GetComponent<Image>().sprite = 지하철의자;

        else if (EndingNumber == 6)
            gameObject.GetComponent<Image>().sprite = 지하철인파;

        else if (EndingNumber == 7)
            gameObject.GetComponent<Image>().sprite = 지하철꼰대;

        else if (EndingNumber == 8)
            gameObject.GetComponent<Image>().sprite = 비둘기;

        else if (EndingNumber == 9)
            gameObject.GetComponent<Image>().sprite = 교수;

        else if (EndingNumber == 14)
            gameObject.GetComponent<Image>().sprite = 휴강;

        else if (EndingNumber == 16)
            gameObject.GetComponent<Image>().sprite = 킥보드;

        else if (EndingNumber == 24)
            gameObject.GetComponent<Image>().sprite = 피시방;

        else if (EndingNumber == 25)
            gameObject.GetComponent<Image>().sprite = 벚꽃엔딩;

        else if (EndingNumber == 26)
            gameObject.GetComponent<Image>().sprite = 버블티;
        else if (EndingNumber == 27)
            gameObject.GetComponent<Image>().sprite = 횡단보도;

    }
}
