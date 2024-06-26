using Firebase;
using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirebaseGuest : MonoBehaviour
{
    [SerializeField]
    string userid;
    public void ClickGuestPlay()
    {
        if (DataManager.instance.nowPlayer.UID !="")
        {
            FirebaseInit();           
        }
        else
        {
            Debug.Log("확인" + DataManager.instance.nowPlayer.UID);
            SceneManager.LoadScene("LoadScene");
        }
    }

    void FirebaseInit()
    {
        StartCoroutine(FirebaseLoginCoroutine());
    }

    IEnumerator FirebaseLoginCoroutine()
    {
        yield return null;
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.SignInAnonymouslyAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInAnonymouslyAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInAnonymouslyAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);

            userid = newUser.UserId;
            DataManager.instance.nowPlayer.UID = userid;            
            DataManager.instance.SaveData();
            DataManager.instance.OnClickSaveButton();
            Debug.Log("확인2" + DataManager.instance.nowPlayer.UID);
            SceneManager.LoadScene("LoadScene");
        });
    }
}