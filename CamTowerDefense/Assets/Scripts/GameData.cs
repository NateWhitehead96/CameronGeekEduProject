using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData instance;
    public int waves; // this will know how many waves we've beaten

    public string[] playerNames; // store all the player names
    public int[] wavesCompleted; // store the waves completed by the player

    private void Awake()
    {
        if(instance != null) // if there is already a game data gameobject then destroy the one in the scene
        {
            Destroy(gameObject);
        }
        else // this is the first game data in our game, make this the only one in our game
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    public void SaveData()
    {
        PlayerPrefs.SetInt("WavesBeaten", waves);
        for (int i = 0; i < playerNames.Length; i++)
        {
            PlayerPrefs.SetString("names" + i, playerNames[i]); // store each name
            PlayerPrefs.SetInt("wavesCompleted" + i, wavesCompleted[i]); // store the waves
        }
    }
    public void LoadData()
    {
        if (PlayerPrefs.HasKey("WavesBeaten"))
        {
            waves = PlayerPrefs.GetInt("WavesBeaten");
            for (int i = 0; i < playerNames.Length; i++)
            {
                playerNames[i] = PlayerPrefs.GetString("names" + i); // load each name
                wavesCompleted[i] = PlayerPrefs.GetInt("wavesCompleted" + i); // load each wave
            }
        }
    }
}
