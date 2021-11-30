using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;

    public List<bool> LevelOneFlies = new List<bool>(); // this will be a list of all the flies we've collected
    public List<bool> LevelTwoFlies = new List<bool>(); // this holds all of our level 2 flies

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int LevelsBeaten;

    private void Start()
    {
        LoadData(); // when we start the game load our data
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("LevelsBeaten", LevelsBeaten); // saving our levels beaten
        PlayerPrefs.SetInt("Score", PlayerControl.Score); // saving our score

    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey("LevelsBeaten"))
        {
            LevelsBeaten = PlayerPrefs.GetInt("LevelsBeaten");
            PlayerControl.Score = PlayerPrefs.GetInt("Score");
        }

    }
}
