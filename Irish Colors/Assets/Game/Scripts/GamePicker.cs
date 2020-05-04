using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePicker : MonoBehaviour {

    //Word Game
    public void WordGames() {
        SceneManager.LoadScene("GamePicker");
    }


    //Colour game
    public void ColourGame() {
        SceneManager.LoadScene("ColourGame");
    }

    //Food Game
    public void FoodGame() {
        SceneManager.LoadScene("FoodGame");
    }

    //Shop Game
    public void ShopGame() {
        SceneManager.LoadScene("ShopGame");
    }

    //Actions - Past Tense
    public void PastActionGame() {
        SceneManager.LoadScene("ActionsGame(past)");
    }
    //Actions - Present Tense
    public void PresentActionGame() {
        SceneManager.LoadScene("ActionsGame(present)");
    }






    //Phrases - New Page with a different approach to the game
    public void PhrasesGame() {
        SceneManager.LoadScene("PhrasesGame");
    }

    //Intro Game
    public void Introduction() {
        SceneManager.LoadScene("Introduction");
    }

    //Age Game
    public void Age() {
        SceneManager.LoadScene("Age");
    }

    //Asking for Game
    public void AskingFor() {
        SceneManager.LoadScene("AskingFor");
    }

    //Directions Game
    public void Directions() {
        SceneManager.LoadScene("Directions");
    }

    //View Leader board
    public void LeaderBoard() {
        SceneManager.LoadScene("LeaderBoard");
    }

    
    public void Profile() {
        SceneManager.LoadScene("Profile");
    }

    //quit game
    public void Back() {
        SceneManager.LoadScene("StartQuit");
    }
}
