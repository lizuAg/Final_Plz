using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniTeacherMoves : MonoBehaviour
{

    float startPos;
    float endPos;
    public float movespeed = 14f;
    public Rigidbody2D rigid;
    public GameObject Student;


    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        startPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        rigid.MovePosition(transform.position + transform.right * Time.deltaTime * movespeed);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.name == "EndLine"){
            movespeed = 0f;
            Debug.Log("게임 종료화면, 교수 이김");
            Student.SetActive(false);
            
        }
    }
}
