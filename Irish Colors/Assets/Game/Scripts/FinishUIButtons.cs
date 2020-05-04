using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishUIButtons : MonoBehaviour {
    //if you want to play the game again
    public void PlayAgain() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //if you want to go pack to chose a different game
    public void GoBack() {
        SceneManager.LoadScene("GamePicker");
    }
}
