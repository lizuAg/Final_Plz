using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fadein : MonoBehaviour
{
    public UnityEngine.UI.Image fade;
<<<<<<< Updated upstream
    float fades = 1.0f;
=======
    public float fades = 1.0f;
>>>>>>> Stashed changes
    float time = 0;

    public void Update()
    {
        fade.gameObject.SetActive(true);
        time += Time.deltaTime;
<<<<<<< Updated upstream
        if(fades > 0.0f && time >= 0.1f)
=======
        if (fades > 0.0f && time >= 0.1f)
>>>>>>> Stashed changes
        {
            fades -= 0.2f;
            fade.color = new Color(0, 0, 0, fades);
            time = 0;
        }
<<<<<<< Updated upstream
        else if(fades <= 0.0f)
=======
        else if (fades <= 0.0f)
>>>>>>> Stashed changes
        {
            time = 0;
        }
    }
}
