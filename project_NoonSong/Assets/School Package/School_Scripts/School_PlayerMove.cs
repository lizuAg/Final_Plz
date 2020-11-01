using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class School_PlayerMove : MonoBehaviour
{
    
    public float jumpPower;
    public float maxSpeed;//속력 상한값 설정
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    private int jumpCheck;
   
    float timer;
    GameObject scanObject;
    public GameManager manager;
    private float speed = 3f;

    public int count_coin=0, count_bread=0;
    bool ending_coin = false; //코인 부자 엔딩(10) 한번만 실행
    bool item_bread = false;
    
    public float ending_laddertime = 0; //사다리 30초 엔딩
    bool breadbox, coinbox; //대학가 빵상자, 코인상자 open

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

        //빵상자
        if(breadbox && Input.GetKeyDown("KeyCode.Z"))
        {
            if(item_bread)
            {
                manager.talkText.text = "이미 획득한 상자입니다.";   
            }
            else
            {
                count_bread += 4;
                manager.talkText.text = "빵 4개를 획득하였습니다!";
            }
            
            breadbox = false;
        }

        //12, 빵엔딩
        if(count_bread == 10)
        {
            manager.talkText.text = "등교길에 빵 10개를 먹는 것은 급성 배탈을 유발한다. 이대로라면 [눈송]은 수업 중에 빵귀를 10번 뀔 것이다. 어쩔 수 없이 병원을 가야겠다.!";
        }

        //29.사다리 시간 엔딩
        if(isLadder){
            ending_laddertime += Time.deltaTime;
            
            if(ending_laddertime >= 30){
                manager.talkText.text = "엔딩) [눈송]은 사다리에 매달려있다가 힘이 모두 빠져버렸다! 눈송은 힘이빠져 제시간에 학교에 가지 못했다!";
            }
            if(!isLadder){
                ending_laddertime = 0; //사다리에서 떨어지면 초기화
            }
        }


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
            anim.SetBool("isUp",true);
            //stop speed = 0 필요?
            
        }
        else{
            rigid.gravityScale = 4f;
        }


    }

    public bool isLadder;
    void OnTriggerEnter2D(Collider2D other)
    {
        

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

            //10. 부자엔딩
            if(count_coin >= 15 && !ending_coin)
            {
                manager.talkText.text = "엔딩)[눈송]은 부자가 되었다! 이제 학교에 다니지 않을것이다! 자퇴!";
                ending_coin = true;
            }
        }
        if(other.gameObject.tag == "Bread"){
            //포인트
            count_bread = count_bread + 1;
            // Deactive item
            other.gameObject.SetActive(false);

            


        }
        else if(other.gameObject.tag == "Box_Bread"){
            breadbox = true;
            manager.talkText.text = "상자를 열려면 z키를 누르세요.";
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        

        //대학가 사다리 접촉 체크
        if(other.CompareTag("Ladders")){
            isLadder = false;
            anim.SetBool("isUp",false);
        }
    }
    
}
