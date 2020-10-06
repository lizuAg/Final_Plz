using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSc : MonoBehaviour
{
    public GameObject AlbumPanel;
    public GameObject creditPanel;
    public GameObject HowtoPanel;
    bool activeAlbum = false;
    bool activeCredit = false;
    bool activeHowto = false;

    private void Start()
    {
        AlbumPanel.SetActive(activeAlbum);
        creditPanel.SetActive(activeCredit);
        HowtoPanel.SetActive(activeHowto);
    }
    //게임 시작 버튼
    public void OnStartingButton()
    {
        //눈송이 방으로 씬 전환
        SceneManager.LoadScene("room");
    }
    //종료버튼
    public void OnQuitButton()
    {
        Application.Quit();
    }
    //앨범 창
    public void OnAlbumButton()
    {
        activeAlbum = !activeAlbum;
        AlbumPanel.SetActive(activeAlbum);
    }
    //크레딧 버튼
    public void OnCredit()
    {
        activeCredit = !activeCredit;
        creditPanel.SetActive(activeCredit);
    }
    //게임방법 창
    public void OnHowtoButton()
    {
        activeHowto = !activeHowto;
        HowtoPanel.SetActive(activeHowto);
    }
    //뒤로가기
    public void ClickedBack()
    {
        if (activeAlbum)
            OnAlbumButton();
        else if (activeCredit)
            OnCredit();
        else if (activeHowto)
            OnHowtoButton();
    }
}
