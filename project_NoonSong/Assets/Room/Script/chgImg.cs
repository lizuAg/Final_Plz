using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chgImg : MonoBehaviour
{
    public Sprite Ending;
    void Update()
    {
        gameObject.GetComponent<Image>().sprite = Ending;
    }
}
