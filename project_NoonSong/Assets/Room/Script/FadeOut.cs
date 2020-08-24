using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Image Panel;
    float time = 0f;
    float FadeTime = 20f;

    public void Fade()
    {
        StartCoroutine(FadeFlow());
    }
    IEnumerator FadeFlow()
    {
        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;

        //Fade Out
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / FadeTime;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        /*time = 0f;

        yield return new WaitForSeconds(1f);

        //Fade In
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / FadeTime;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        Panel.gameObject.SetActive(false);
        yield return null;*/
    }
}
