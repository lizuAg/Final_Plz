using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnType : MonoBehaviour
{
    public BTNType currentType;
    //public Transform buttonScale;
    //Vector3 defaultScale;

    private void Start(){
        
       // defaultScale = buttonScale.localScale;
    }
    public void OnBtnClick(){
        switch (currentType){
            case BTNType.New:
                Debug.Log("새 게임");
                break;
            case BTNType.Quit:
                Debug.Log("나가기");
                break;
        }
    }
    

//    public void OnPointerEnter(PointerEventData eventData){
//        buttonScale.localScale = defaultScale *1.2f;
//    }

//    public void OnPointerExit(PointerEventData eventData){
 //       buttonScale.localScale = defaultScale;
 //   }
}


