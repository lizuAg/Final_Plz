using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkmanager;
    public Text talkText;
    public GameObject talkPanel;
    public bool isAction;
    public GameObject scanObject;

    public void Action(GameObject scanObj)
    {
        if (isAction)//exit action
        {
            talkPanel.SetActive(false);
        }
        else//enter action
        {
            talkPanel.SetActive(true);
            scanObject = scanObj;
            talkText.text = "이것의 이름은" + scanObject.name + "이라고 한다.";
        }
        talkPanel.SetActive(isAction);
    }
}
