using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Night : MonoBehaviour
{
    public GameObject NightPanel;
    private bool isNight = false;
    private float timer;
    void Start()
    {
        if (Random.Range(1, 10) == 1)
            isNight = true;
        NightPanel.SetActive(isNight);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (isNight&&timer>3)
        {
            Debug.Log("늦잠자서 지각엔딩... ㅎㅎ...");
        }

    }
}
