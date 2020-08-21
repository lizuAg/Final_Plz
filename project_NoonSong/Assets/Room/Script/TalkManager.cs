using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;//<key,value>

    void Awake()
    {
        talkData = new Dictionary<int, string[]>(); //초기화
        GenerateData();
    }


    void GenerateData()
    {
        talkData.Add(2,new string[] {"어 컴퓨터다.","한 번 켜볼까? \n(윗방향키로 컴퓨터를 켤 수 있습니다.)"});
        talkData.Add(1, new string[] { "침대다. 자고싶어.." });
    }

    public string GetTalk(int id, int talkIndex)
    {
        return talkData[id][talkIndex];
    }
}
