using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EndingArray
{
    static public bool[] endArray = new bool[50];
    /*void Start()
    {
        for (int i=0;i<50;i++){
            endArray[i] = false;
        }   
    }
    void Update()
    {
        if (endArray[0])
        {
            Debug.Log("오 됐다...!");
        }
    }*/
    public static void setEndArray(int i)
    {
        endArray[i] = true;
    }
}
