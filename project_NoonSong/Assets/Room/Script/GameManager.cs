﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public Text talkText;
    public GameObject talkPanel;
    public GameObject scanObject;
    public bool isAction;
    public bool isClicked;
    public int talkIndex;
    public GameObject EndingImg;
    public GameObject frame;
    float timer = 0f;
    public GameObject btn;

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNpc);

        talkPanel.SetActive(isAction);
    }
    public void Img()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            talkPanel.SetActive(true);
            frame.SetActive(true);
            EndingImg.SetActive(true);
            btn.SetActive(true);
        }
        if (isClicked)
        {
            frame.SetActive(false);
            btn.SetActive(false);
        }
    }
    public void SetBtn()
    {
        isClicked = true;
        frame.SetActive(false);
        btn.SetActive(false);
    }
    void Talk(int id, bool isNpc)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);

        if(talkData == null) //대화 끝
        {
            talkIndex = 0;
            isAction = false;
            return;
        }
        if (isNpc)
        {
            talkText.text = talkData;
        }
        else
        {
            talkText.text = talkData;
        }
        isAction = true;
        talkIndex++;
    }
}
