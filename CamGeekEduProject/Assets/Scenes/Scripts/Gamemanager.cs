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

        for (int i = 0; i < LevelOneFlies.Count; i++)
        {
            PlayerPrefs.SetInt("LevelOneFly" + i, LevelOneFlies[i] ? 1 : 0); // saving each fly bool by using the name + i and using ? operator to check if its 1 or 0 aka true or false
        }
        for (int i = 0; i < LevelTwoFlies.Count; i++)
        {
            PlayerPrefs.SetInt("LevelTwoFly" + i, LevelTwoFlies[i] ? 1 : 0); // saving each fly bool by using the name + i and using ? operator to check if its 1 or 0 aka true or false
        }
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey("LevelsBeaten"))
        {
            LevelsBeaten = PlayerPrefs.GetInt("LevelsBeaten");
            PlayerControl.Score = PlayerPrefs.GetInt("Score");
        }

        for (int i = 0; i < LevelOneFlies.Count; i++)
        {
            LevelOneFlies[i] = PlayerPrefs.GetInt("LevelOneFly" + i) == 1; // load each bool back into our level one fly list. we do a == at the end to do a check to see if the bool is = to 1
        }
        for (int i = 0; i < LevelTwoFlies.Count; i++)
        {
            LevelTwoFlies[i] = PlayerPrefs.GetInt("LevelTwoFly" + i) == 1; // load each bool back into our level one fly list. we do a == at the end to do a check to see if the bool is = to 1
        }
    }
}
