using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AuthController : MonoBehaviour {
    public Text EmailInput;
    public Text PasswordInput;

    private bool Jump = false;

    private void Update() {
        if (Jump == true) SceneManager.LoadScene("StartQuit");
    }

    public void LogIn() {
        FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(EmailInput.text, PasswordInput.text).ContinueWith((
            task => {
                if (task.IsCanceled) {
                }

                if (task.IsFaulted) {
                    Firebase.FirebaseException e =
                        task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;
                    
                    LogErrorMessage((AuthError) e.ErrorCode);
                }

                if (task.IsCompleted) {
                    Jump = true;
                }
                
            }));

        //if (Jump) SceneManager.LoadScene("StartQuit");
    }

    public void Register() {
        FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(EmailInput.text, PasswordInput.text)
            .ContinueWith((
                task => {
                    if (task.IsCanceled) {
                        Firebase.FirebaseException e =
                            task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;
                    
                        LogErrorMessage((AuthError) e.ErrorCode);
                    }

                    if (task.IsFaulted) {
                        Firebase.FirebaseException e =
                            task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;
                    
                        LogErrorMessage((AuthError) e.ErrorCode);
                    }

                    if (task.IsCompleted) {
                        Jump = true;
                    }
                }));

        //if (Jump) SceneManager.LoadScene("StartQuit");
    }

    public void Anonymus() {
        FirebaseAuth.DefaultInstance.SignInAnonymouslyAsync()
            .ContinueWith((task => {
                if (task.IsCanceled) {
                }

                if (task.IsFaulted) {
                    Firebase.FirebaseException e =
                        task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;
                    
                    LogErrorMessage((AuthError) e.ErrorCode);
                }

                if (task.IsCompleted) {
                    SceneManager.LoadScene("StartQuit");
                }
            }));
    }

    private void LogErrorMessage(AuthError authError) {
        print(authError.ToString());
        print(EmailInput.text);
        print(PasswordInput.text);
    }
    
    
}
