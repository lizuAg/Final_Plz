using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImg : MonoBehaviour
{
    public Sprite 지하철의자;
    public Sprite 지하철인파;
    public PlayerMove_room Game;

    public void Change(int EndingNumber)
    {
        if (EndingNumber == 5)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = 지하철인파;
        }
        else if (EndingNumber == 6)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = 지하철의자;
        }
    }
}