using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeBubble : MonoBehaviour
{
    [SerializeField]
    public GameObject bubble;
    private int score;
    public Text scoreText;

    void Start()
    {
        CreateBubble();
        StartCoroutine(CreatebubbleRoutine());
    }
    IEnumerator CreatebubbleRoutine()
    {
        while (true)
        {
            CreateBubble();
            yield return new WaitForSeconds(0.5f);
        }
    }
    public void Score()
    {
        score++;
        scoreText.text = "획득 버블 " + score +"개";
    }
    private void CreateBubble()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f,1.0f),1.1f,0));
        pos.z = 0.0f;
        Instantiate(bubble, pos, Quaternion.identity);
    }
}
