using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Potal : MonoBehaviour
{
    void Awake()
    {

    }

    void Update()
    {

    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("윗방향키를 눌러주세요.1");
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                SceneManager.LoadScene("SubwayScene");
            }
        }
    }
}