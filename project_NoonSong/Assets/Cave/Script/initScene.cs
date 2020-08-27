using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initScene : MonoBehaviour
{
    public Transform enemy_prefab;

    void Awake()
    {
        for(int i = -4; i < 5; i++)
        {
            Instantiate(enemy_prefab, new Vector2(i * 3.0f, 8), Quaternion.identity);
        }
    }
}
