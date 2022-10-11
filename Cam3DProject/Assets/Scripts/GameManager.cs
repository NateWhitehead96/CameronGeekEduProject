using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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

    public int levelsBeaten; // variable we save and load to know what levels we have completed
    // Start is called before the first frame update
    void Start()
    {
        LoadGame(); // whenever we start, load in our data
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("Level", levelsBeaten); // save what level we're on
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("Level")) // only if we've saved before, load in the data
        {
            levelsBeaten = PlayerPrefs.GetInt("Level");
        }
    }
}
