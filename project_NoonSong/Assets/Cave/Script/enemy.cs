using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform Enemy_prefab;
    private float moveSpeed;

    void Start()
    {
        moveSpeed = Random.Range(3, 8);
    }
    void Update()
    {
        if (gameObject.activeSelf == true)
        {
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        }
        if (transform.position.y < -10)
        {
            Vector2 pos = gameObject.transform.position;
            Instantiate(Enemy_prefab, new Vector2(pos.x, 13), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
