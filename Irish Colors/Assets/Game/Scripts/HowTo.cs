using System;
using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class HowTo : MonoBehaviour {
    public AudioClip[] tests;
    public AudioSource AS;
    public GameObject FinishUI;
    //public Text ScoreText;
    
    //private int Score;
    private String[] Test = {"Flag", "Knot"};
    private int Counter;
    private int SetUp;
    private Player player;
    
    private static string DATABASE_URL = "https://fir-game-c590f.firebaseio.com/";
    private DatabaseReference database;
    
    // Start is called before the first frame update
    void Start() {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(DATABASE_URL);
        database = FirebaseDatabase.DefaultInstance.RootReference;
        
        player = new Player();
        player.email = FirebaseAuth.DefaultInstance.CurrentUser.Email;

        FirebaseDatabase.DefaultInstance.GetReferenceFromUrl(DATABASE_URL).GetValueAsync().ContinueWith((task => {
            if (task.IsCompleted) {
                DataSnapshot snapshot = task.Result;

                //string playerData = snapshot.GetRawJsonValue();
                foreach (var child in snapshot.Children) {
                    string ps = child.GetRawJsonValue();
                    Player p = JsonUtility.FromJson<Player>(ps);

                    if (p.email == player.email) player = p;
                }
            }
        }));
        
        //string jsonPlayer = JsonUtility.ToJson(player);
        //database.Child(FirebaseAuth.DefaultInstance.CurrentUser.UserId).SetRawJsonValueAsync(jsonPlayer);
        
        //Score = 0;
        Counter = 0;
        SetUp = 1000;

        this.gameObject.tag = Test[Counter];
        AS.clip = tests[Counter];
        AS.Play();
    }

    void FixedUpdate() {
        if (SetUp == 1000) return;
        if (SetUp == 120 && Counter < 6) {
            this.gameObject.tag = Test[Counter];
            AS.clip = tests[Counter];
            AS.Play();
            
            SetUp = 1000;
        }

        ++SetUp;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        AS.clip = other.gameObject.GetComponent<AudioSource>().clip;
        AS.Play();
        
        Destroy(other.gameObject);
        
        ++Counter;
        
        if (Counter >= 2) {
            FinishUI.SetActive(true);
            string jsonPlayer = JsonUtility.ToJson(player);
            database.Child(FirebaseAuth.DefaultInstance.CurrentUser.UserId).SetRawJsonValueAsync(jsonPlayer);
                    
            return;
        }
        
        SetUp = 0;
    }
}
