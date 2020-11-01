using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove_room : MonoBehaviour
{
    public float jumpPower;
    public float maxSpeed;//속력 상한값 설정
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    private int jumpCheck;
    private bool isOnbed;
    float timer = 0f;
    GameObject scanObject;
    public GameManager manager;
    public FadeOut fadeout;
    public GameObject frame;

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
                    manager.talkText.text = "탄력적인 침대는 [눈송]을 천장을 뚫고 날려버렸다~~!";
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
    }
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
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "bedCheck")
        {
            Debug.Log("Exit");
            isOnbed = false;
            jumpCheck = 0;
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
            manager.talkText.text = "앉으려면 아래 방향키를 누르세요.";
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                manager.talkPanel.SetActive(false);
                anim.SetBool("isSitting", true);
                timer += Time.deltaTime;
                if (timer > 0.3)
                {
                    EndingScene();
                    manager.talkText.text = "눈송이는 의자에 엉덩이가 붙어 학교에 지각했다..";
                    anim.SetBool("isSitting", false);
                }
            }
        }
        else if(other.gameObject.name == "frontdoor")
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                manager.talkText.text = "사람이 너무 많은 곳으로 내리려다... 인파에 파묻혔다!!";
                EndingScene();
            }
        }
    }
    void EndingScene()
    {
        fadeout.OutFade();
        manager.Img();
        if (manager.isClicked == true)
        {
            fadeout.InFade();
            transform.position = new Vector3(-15, 0, 0);
            manager.talkPanel.SetActive(false);
            timer = 0;
            manager.isClicked = false;
        }
    }
}
