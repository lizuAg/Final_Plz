using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlbumCs : MonoBehaviour
{
    public Button[] btns = new Button[50];
    //public Image btnImg;

    public GameObject parent;
    public Button btnPrefab;
    void Awake()
    {
        //버튼 초기화
        for (int i=1; i<50;i++)
        {
            //버튼 생성
            btns[i] = Instantiate(btnPrefab);
            btns[i].transform.SetParent(parent.transform, false);
            btns[i].GetComponentInChildren<Text>().text = i.ToString();

            //엔딩 봤는지 검사
            if (EndArray.getEndingArray(i))
                btns[i].interactable = true;
            else
            {
                btns[i].interactable = false;
            }
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
