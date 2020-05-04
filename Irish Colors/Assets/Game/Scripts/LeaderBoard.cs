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


public class LeaderBoard : MonoBehaviour {
    public Text LeaderBoardText;

    private List<Player> players = new List<Player>(); //making a list to store all players
    private static string DATABASE_URL = "https://fir-game-c590f.firebaseio.com/";
    private DatabaseReference database;


    void Start() {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(DATABASE_URL);
        database = FirebaseDatabase.DefaultInstance.RootReference;
        

        FirebaseDatabase.DefaultInstance.GetReferenceFromUrl(DATABASE_URL).GetValueAsync().ContinueWith((task => {
            if (task.IsCompleted) {
                DataSnapshot snapshot = task.Result;

                //string playerData = snapshot.GetRawJsonValue();
                foreach (var child in snapshot.Children) {
                    string ps = child.GetRawJsonValue();
                    Player p = JsonUtility.FromJson<Player>(ps);

                    players.Add(p); 
                }

                //sorting
                //if (players.Count > 0)
                //{
                //    players.Sort(delegate(Player a, Player b)
                //    {
                //        return (a.score<b.score);
                //    });
                //}

                //print
                foreach(var pl in players) 
                { 
                    LeaderBoardText.text += pl.email + ": " + pl.score + "\n";           
                }
            }
        }));
    }
}