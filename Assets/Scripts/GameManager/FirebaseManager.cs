using Firebase;
using Firebase.Auth;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirebaseManager
{
    private  static FirebaseManager instance = null;

    private FirebaseAuth auth;
    private FirebaseUser user;
    
    private string displayName;
    private string emailAddress;
    private Uri photoUrl;
    public Action<bool> OnChangedLoginState;

    public static FirebaseManager Instance
    {
        get
        { 
            if (instance == null)
            {
                instance = new FirebaseManager();
            }
            return instance;
        }
    }

    public string UserId => user?.UserId ?? string.Empty;
    public string DisplayeName => displayName;
    public string EmailAddress => emailAddress;
    public Uri PhotoUrl => photoUrl;

    public void InitializeFirebase()
    {
        auth = FirebaseAuth.DefaultInstance;
        auth.StateChanged += OnAuthStateChanged;

        OnAuthStateChanged(this, null);
    }

    public void CreateUser(string email, string password)
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if(task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled");
                return;
            }
            if(task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error:" + task.Exception);

                int errorCode = GetFirebaseErrorCode(task.Exception);
                switch(errorCode)
                {
                    case (int)AuthError.EmailAlreadyInUse:
                        Debug.LogError("Email Already In Use");
                        break;

                    case (int)AuthError.InvalidEmail:
                        Debug.LogError("Invalid Email");
                        break;

                    case (int)AuthError.WeakPassword:
                        Debug.LogError("Weak Password");
                        break;    

                }

                return;
            }

            FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})", newUser.DisplayName, newUser.UserId);
        });
    }

    public void SignIn(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>{
            if(task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled");
                return;
            }
            if(task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error:" + task.Exception);

                int errorCode = GetFirebaseErrorCode(task.Exception);
                switch(errorCode)
                {
                    case (int)AuthError.WrongPassword:
                        Debug.LogError("Wrong Password");
                        break;

                    case (int)AuthError.UnverifiedEmail:
                        Debug.LogError("Unverified Email");
                        break;

                    case (int)AuthError.InvalidEmail:
                        Debug.LogError("Invalid Email");
                        break;    

                }

                return;
            }

            FirebaseUser newUser = task.Result;
            if(newUser == task.Result)
            {
                SceneManager.LoadScene("LoadScene");
            }
            Debug.LogFormat("Firebase Signed in successfully: {0} ({1})", newUser.DisplayName, newUser.UserId);
            
        });
        
    }

    public void SignOut()
    {
        auth.SignOut();
        LoadingBar.LoadScene("LoginScene");
    }   

    private int GetFirebaseErrorCode(AggregateException exception)
    {
        FirebaseException firebaseException = null;
        foreach (Exception e in exception.Flatten().InnerExceptions)
        {
            firebaseException = e as FirebaseException;
            if(firebaseException != null)
            {
                break;
            }
        }
        
        return firebaseException?.ErrorCode ?? 0;
    }


    private void OnAuthStateChanged(object sender, EventArgs eventArgs)
    {
        if(auth.CurrentUser != user)
        {
            bool signedIn = (user != auth.CurrentUser && auth.CurrentUser != null);
            if(!signedIn && user != null)
            {
                Debug.Log("Signed Out:" + user.UserId);
                OnChangedLoginState?.Invoke(false);
            }

            user = auth.CurrentUser;
            if(signedIn)
            {
                Debug.Log("Signed In:" + user.UserId);

                displayName = user.DisplayName ?? string.Empty;
                emailAddress = user.Email ?? string.Empty;
                photoUrl = user.PhotoUrl ?? null;

                OnChangedLoginState?.Invoke(true);
                SceneManager.LoadScene("LoadScene");
            }
        }
    } 
}
