using System.Collections;
using System.Collections.Generic;
using Firebase.Auth;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartQuit : MonoBehaviour {

    public void StartGame() {
        SceneManager.LoadScene("GamePicker");
    }


    public void HowTo() {
        SceneManager.LoadScene("HowTo");
    }



    public void Quit() {
        if (FirebaseAuth.DefaultInstance.CurrentUser != null) FirebaseAuth.DefaultInstance.SignOut();

        Application.Quit();
    }
    
}
