using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData instance;
    public int waves; // this will know how many waves we've beaten

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
    }
    public void LoadData()
    {
        if (PlayerPrefs.HasKey("WavesBeaten"))
        {
            waves = PlayerPrefs.GetInt("WavesBeaten");
        }
    }
}
