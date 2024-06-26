using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static DataManager;

public class LoadManager : MonoBehaviour
{
    public GameObject UpdatePopWindow;
    public Text _text;
    public void SecenChange()
    {
        DataManager.instance.audioSource.volume = 0.2f;
        //LoadingBar.LoadScene("SelectScene");
        DataManager.instance.VersionChecking();
        StartCoroutine("ChangeImage");
        Invoke("go", 3.0f);
    }

    public void go()
    {
        if (DataManager.instance.ver == Application.version)
        {
            _text.text = "실행 중 입니다.";
            LoadingBar.LoadScene("SelectScene");
        }
        else
        {
            UpdatePopWindow.SetActive(true);
        }
    }
    public void gotoStore()
    {
        Application.OpenURL("market://details?id=com.kyunigames.slimehuntingsurvivor");

        //https://play.google.com/store/apps/details?id=com.kyunigames.slimehuntingsurvivor
        //market://details?id=com.kyunigames.slimehuntingsurvivor
    }

    public void logouttest()
    {
        FirebaseManager.Instance.SignOut();
    }

    IEnumerator ChangeImage() 
    {
        for (int i = 0; i < 3; i++)
        {
            _text.text = "버전 확인 중 입니다...." + (3 - i).ToString();
            yield return new WaitForSeconds(1f);
        }
    }
}
