using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Image Panel;
    float time = 0f;
    float FadeTime = 20f;

    public void OutFade()
    {
        StartCoroutine(FadeFlow());
    }
    public void InFade()
    {
        StartCoroutine(FadeinFlow());
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
    }
    IEnumerator FadeinFlow()
    {
        yield return new WaitForSeconds(1);
        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        alpha.a = 0.1f;
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / FadeTime;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }
        Panel.gameObject.SetActive(false);
    }
}