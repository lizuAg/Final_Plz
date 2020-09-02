using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public GameObject bubble;
    [SerializeField]
    void Start()
    {
        StartCoroutine(CreateBubbleRoutine());
    }

    private void CreateBubble()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f,1.0f),1.1f,0));
        pos.z = 0.0f;
        Instantiate(bubble, pos, Quaternion.identity); //Quaternion.identity오브젝트회전금지
    }

    IEnumerator CreateBubbleRoutine()
    {
        while (true) {
            CreateBubble();
            yield return new WaitForSeconds(1); }
    }
}
