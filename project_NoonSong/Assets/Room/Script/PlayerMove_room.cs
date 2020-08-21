using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_room : MonoBehaviour
{
    public float jumpPower;
    public float maxSpeed;//속력 상한값 설정
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    private int jumpCheck;
    private bool isOnbed;
    float timer;
    private float speed = 3f;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        //Jump
        if (Input.GetButtonDown("Jump") && !anim.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
            //침대에서 점프
            if (isOnbed)
            {
                Debug.Log("침대에서 점프횟수: " + (++jumpCheck));
                if (jumpCheck ==5)
                {
                    rigid.AddForce(new Vector2 (3,8), ForceMode2D.Impulse);
                    Debug.Log("침대점프엔딩!~~!~~!");
                }
            }
        }
        //Stop Speed
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }
        //Direction Sprite 방향전환
        if (Input.GetButton("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        //Animation
        if (Mathf.Abs(rigid.velocity.x) < 0.3) //절댓값이 0.3보다 작으면(멈추면)
            anim.SetBool("isWalking", false);
        else
            anim.SetBool("isWalking", true);
    }
    void FixedUpdate()
    {
        //Move By Key Control
        float h = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * h * 2, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed) //Right Max Speed, 너무 빠를 때
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed * (-1)) //Left Max Speed
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);//y축을 0으로 잡으면 공중에 안뜸

        //Landing Platform
        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down * (1), new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.6f)
                {
                    anim.SetBool("isJumping", false);
                    anim.SetBool("isSitting", false);
                }
            }
        }

        //대학가 사다리
        if(isLadder){
            float ver = Input.GetAxis("Vertical");
            rigid.gravityScale = 0;
            rigid.velocity = new Vector2(rigid.velocity.x, ver*speed);

            //stop speed = 0 필요?
            
        }
        else{
            rigid.gravityScale = 4f;
        }


    }

    public bool isLadder;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "bedCheck")
        {
            Debug.Log("Enter");
            isOnbed = true;
        }
        else if(other.gameObject.tag == "door") //지하철 문이동
        {
            transform.Translate(22, 0, 0);
        }

        //대학가 사다리 접촉 체크
        if(other.CompareTag("Ladders")){
            isLadder = true;
        }

        //coin,아이템
        if(other.gameObject.tag == "Item"){
            //포인트

            // Deactive item
            other.gameObject.SetActive(false);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "bedCheck")
        {
            Debug.Log("Exit");
            isOnbed = false;
            jumpCheck = 0;
        }

        //대학가 사다리 접촉 체크
        if(other.CompareTag("Ladders")){
            isLadder = false;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "com")
        {
            Debug.Log("윗방향키를 눌러주세요.");
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                Debug.Log("컴퓨터엔딩~!~!~!");
            }
        }
        else if (other.gameObject.name == "chairCollider")
        {
            timer += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                anim.SetBool("isSitting", true);
                if (timer > 3)
                {
                    Debug.Log("의자엔딩~!~!");
                    transform.position = new Vector3(-15,0,0);
                    anim.SetBool("isSitting", false);
                    timer = 0;
                }
            }
        }
        else if(other.gameObject.name == "frontdoor")
        {
            timer += Time.deltaTime;
            if(timer>1)
                Debug.Log("사람이 너무 많습니다.");
        }
    }
}
