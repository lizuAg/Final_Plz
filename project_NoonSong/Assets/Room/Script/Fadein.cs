using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fadein : MonoBehaviour
{
    public UnityEngine.UI.Image fade;
    public float fades = 1.0f;
    float time = 0;

    public void Update()
    {
        fade.gameObject.SetActive(true);
        time += Time.deltaTime;
        if (fades > 0.0f && time >= 0.1f)
        {
            fades -= 0.2f;
            fade.color = new Color(0, 0, 0, fades);
            time = 0;
        }
        else if (fades <= 0.0f)
        {
            time = 0;
        }
    }
}
