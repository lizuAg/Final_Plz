using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    static public bool[] endArray = new bool[50];

    void Start()
    {
        for (int i=0;i<50;i++){
            endArray[i] = false;
        }   
    }
}
