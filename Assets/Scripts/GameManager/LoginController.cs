using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LoginController : MonoBehaviour
{
    public InputField emailInputField;
    public InputField passwordInputField;
    public Text outputText;   
   
    void Start() 
    {
        FirebaseManager.Instance.OnChangedLoginState += OnChangedLoginState;
        FirebaseManager.Instance.InitializeFirebase();
    }

    public void CreateUser()
    {
        string email = emailInputField.text;
        string password = passwordInputField.text;

        FirebaseManager.Instance.CreateUser(email, password);
    }

    public void SignIn()
    {
        string email = emailInputField.text;
        string password = passwordInputField.text;

        FirebaseManager.Instance.SignIn(email, password);        
    }
    
    public void SignOut()
    {
        FirebaseManager.Instance.SignOut();
    }

    private void OnChangedLoginState(bool signedIn)
    {
        outputText.text = signedIn ? "Signed In" : "Signed Out";
        outputText.text += FirebaseManager.Instance.UserId;        
    }
}
