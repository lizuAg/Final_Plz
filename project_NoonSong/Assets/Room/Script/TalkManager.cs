using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1, new string[] { "탁자 위에 분홍색 꽃이 들어있는 작은 화분이 있다." });
        talkData.Add(2, new string[] { "컴퓨터가 놓여져 있다.","게임을 하고 싶은 욕구가 차오른다..!","키보드의 위 방향키를 누르면 전원을 킬 수 있을 것 같다."});
        talkData.Add(20, new string[] { "개찰구이다. 지나갈 수 있다." });
        talkData.Add(25, new string[] { "atm 기계이다. 작동 중인 것 같다." });
        talkData.Add(30, new string[] { "비상 시를 대비한 소화기다." });
    }
    public string GetTalk(int id, int talkIndex) //id는 번호값 index는 배열인덱스
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
}
