using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform target;

    void Start(){

    }

    void LateUpdate(){
        //카메라위치설정(x,y,z)
        transform.position = new Vector3(target.position.x, target.position.y + 2, -10f);
        
    }
}
