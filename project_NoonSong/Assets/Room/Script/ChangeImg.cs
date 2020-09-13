using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImg : MonoBehaviour
{
    public Image FirstImg;
    public Sprite ChangeSprite;

    public void Change()
    {
        FirstImg.sprite = ChangeSprite;
    }
}
