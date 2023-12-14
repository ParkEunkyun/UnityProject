
using Firebase.Auth;
using GooglePlayGames.BasicApi;
using GooglePlayGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GoogleLogin : MonoBehaviour
{
    FirebaseAuth fbAuth;
    public Text outputText;


    void Start()
    {
        FirebaseManager.Instance.OnChangedLoginState += OnChangedLoginState;
        FirebaseManager.Instance.InitializeFirebase();

        PlayGamesPlatform.InitializeInstance(new PlayGamesClientConfiguration.Builder()
            .RequestIdToken()
            .RequestEmail()
            .Build());
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();

        fbAuth = FirebaseAuth.DefaultInstance;

        TryGoogleLogin();
    }
    public void googlebutton()
    {
        PlayGamesPlatform.InitializeInstance(new PlayGamesClientConfiguration.Builder()
            .RequestIdToken()
            .RequestEmail()
            .Build());
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();

        fbAuth = FirebaseAuth.DefaultInstance;

        TryGoogleLogin();
}

public void TryGoogleLogin()
    {
        PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptAlways, (success) =>
        {
            if (success == SignInStatus.Success)
            {
                Debug.Log("Google Success");
                StartCoroutine(TryFirebaseLogin());
            }
            else
            {
                Debug.Log("Google Failure");
                Debug.LogError($"Google login error msg: {success}");
            }
        });
    }


    public void TryGoogleLogout()
    {
        if (Social.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.SignOut();
            fbAuth.SignOut();
        }
    }


    IEnumerator TryFirebaseLogin()
    {
        while (string.IsNullOrEmpty(((PlayGamesLocalUser)Social.localUser).GetIdToken()))
        {
            yield return null;
        }

        string idToken = ((PlayGamesLocalUser)Social.localUser).GetIdToken();

        Credential credential = GoogleAuthProvider.GetCredential(idToken, null);

        fbAuth.SignInWithCredentialAsync(credential).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.Log("Firebase Canceled");
            }
            else if (task.IsFaulted)
            {
                Debug.Log("Firebase Faulted");
            }
            else
            {
                Debug.Log("Firebase Success");
            }
        });

        FirebaseManager.Instance.OnChangedLoginState += OnChangedLoginState;
        FirebaseManager.Instance.InitializeFirebase();
    }

    private void OnChangedLoginState(bool signedIn)
    {
        outputText.text = signedIn ? "Signed In" : "Signed Out";
        outputText.text += FirebaseManager.Instance.UserId;
    }
}
/*
using GooglePlayGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoogleLogin : MonoBehaviour
{
    public Text LogText;
    // Start is called before the first frame update
    void Start()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        LogIn();
        
    }

    public void LogIn()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success) LogText.text = Social.localUser.id + "\n" + Social.localUser.userName;
            else LogText.text = "구글 로그인 실패";
        });
    }

    public void LogOut()
    {
        ((PlayGamesPlatform)Social.Active).SignOut();
        LogText.text = "구글 로그아웃";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}*/