using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    void Start()
    {
        animator.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            animator.SetTrigger("bubble");
        }
        if (collision.gameObject.tag == "Player")
        {
            animator.SetTrigger("bubble");
        }
    }
}
