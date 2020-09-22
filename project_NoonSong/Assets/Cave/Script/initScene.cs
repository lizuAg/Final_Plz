using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class initScene : MonoBehaviour
{
    public Transform enemy_prefab;
    public Text batText;
    public Text timeText;
    public static int batNum=0;
    public int time;

    void Awake()
    {
        for(int i = -4; i < 5; i++)
        {
            Instantiate(enemy_prefab, new Vector2(i * 3.0f, 8), Quaternion.identity);
        }
    }
    void Start()
    {
        batText.text = "잡은 박쥐 수: " + batNum + "/30";//숫자는 조정.
        timeText.text = "남은 시간: " + time;
    }
    void FixedUpdate()
    {
        batText.text = "잡은 박쥐 수: " + batNum + "/30";//숫자는 조정.
        timeText.text = "남은 시간: " + time;
    }
}
