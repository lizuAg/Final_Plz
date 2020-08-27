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
    GameObject scanObject;
    public GameManager manager;
    private float speed = 3f;

    public int count_coin=0, count_bread=0;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        //Jump
        if (manager.isAction ? false : Input.GetButtonDown("Jump") && !anim.GetBool("isJumping"))
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
                    manager.talkText.text = "탄력적인 침대는 [눈송]을 천장을 뚫고 날려버렸다~~!";
                }
            }
        }
        //Stop Speed
        if (manager.isAction ? false : Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }
        //Direction Sprite 방향전환
        if (manager.isAction ? false :Input.GetButton("Horizontal"))
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
        float h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");

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

        Debug.DrawRay(rigid.position, Vector3.right * (1), new Color(0, 1, 0));
        RaycastHit2D rayHit2 = Physics2D.Raycast(rigid.position, Vector3.right, 1, LayerMask.GetMask("Object"));
        if (rayHit2.collider != null) //스캔한 오브젝트 저장
        {
            scanObject = rayHit2.collider.gameObject;
        }

        if (Input.GetKeyDown(KeyCode.Z) && scanObject != null) //오브젝트 스캔
        {
            manager.Action(scanObject);
            scanObject = null;
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
        if(other.gameObject.tag == "Coin"){
            //포인트
            count_coin = count_coin + 1;
            // Deactive item
            other.gameObject.SetActive(false);
        }
        if(other.gameObject.tag == "Bread"){
            //포인트
            count_bread = count_bread + 1;
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
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                manager.talkText.text = "눈송은 컴퓨터의 유혹에 빠져...학교에 늦어버렸다!!";
                manager.isAction = false;
            }
        }
        else if (other.gameObject.name == "chairCollider")
        {
            manager.talkText.text = "아래 방향키를 연타하세요 !";
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                anim.SetBool("isSitting", true);
                timer += Time.deltaTime;
                Debug.Log("앉은 시간 : " + timer);
                if (timer > 0.3)
                {
                    manager.talkText.text = "눈송이는 의자에 엉덩이가 붙어 학교에 지각했다..";
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
