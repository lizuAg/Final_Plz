using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Transform enemy_prefab;

    void Update()
    {
        if (transform.position.y > 20)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Vector2 pos = other.gameObject.transform.position;
            Destroy(other.gameObject);
            initScene.batNum++;
            Instantiate(enemy_prefab, new Vector2(pos.x, 20), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
