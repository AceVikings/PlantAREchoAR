using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using Proyecto26;
using UnityEngine.SceneManagement;
public class AuthController : MonoBehaviour
{
    
    public static bool LoggedIn = false;
    public InputField emailInput, passwordInput;
    public GameObject authPanel, registrationPanel;
    
    public void Login()
    {
        FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(emailInput.text,
            passwordInput.text).ContinueWith((task =>
            {
                if (task.IsCanceled)
                {
                    Firebase.FirebaseException e =
                    task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;
                    GetErrorMessage((AuthError)e.ErrorCode);
                    return;
                }
                if (task.IsFaulted)
                {
                    Firebase.FirebaseException e =
                    task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;
                    GetErrorMessage((AuthError)e.ErrorCode);
                    return;
                }

                if (!task.IsCompleted) return;
                LoggedIn = true;
                
                
            }));
            SceneManager.LoadScene("SimpleAR");
    }

    void Update()
    {
        
    }
   
    
    
    public void Logout()
    {
        if(FirebaseAuth.DefaultInstance.CurrentUser != null)
        {
            FirebaseAuth.DefaultInstance.SignOut();
            print("User is Logged Out");
        }

        SceneManager.LoadScene("AuthScene");
    }

    void GetErrorMessage(AuthError errorCode)
    {
        string msg = "";
        msg = errorCode.ToString();
        print(msg);
    }

    
    public void Register()
    {
        authPanel.SetActive(false);
        registrationPanel.SetActive(true);
        
    }

    
}
