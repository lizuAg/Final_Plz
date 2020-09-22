using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSchool : MonoBehaviour
{
    
    float startPos; // 몬스터 시작위치
    float endPos; // 몬스터 마지막 위치
    public int patrolArea = 9; //몬스터 이동 구간 길이
    public float moveSpeed = 10f; // 몬스터 이동 속도
    public Rigidbody2D rigid;

    bool moveRight = true; //왼쪽, 오른쪽 방향 체크

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        startPos = transform.position.x; // x값 초기화
        endPos = transform.position.x + patrolArea;; // 이동 구간 더해 끝 구간 체크

    }

    // Update is called once per frame
    void Update()
    {
        if(moveRight){ //오른쪽 이동
            rigid.MovePosition(transform.position + transform.right * Time.deltaTime * moveSpeed);
        }

        if(transform.position.x > endPos){ //끝에 도달하면 왼쪽방향으로 가도록
            moveRight = false;
        }

        if(!moveRight){ //왼쪽 이동
            rigid.MovePosition(transform.position - transform.right * Time.deltaTime * moveSpeed);
        }
        
        if(transform.position.x < startPos){ //왼쪽 끝에 도달하면 오른쪽 방향으로 가도록
            moveRight = true;
        }

    }
}
