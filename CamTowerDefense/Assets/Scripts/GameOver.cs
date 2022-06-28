using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text WaveCompleted; // help display how many waves you beat
    public ZombieSpawner spawner;
    public GameObject selector; // so we can destroy this gameobject
    public InputField nameField; // where the player can input a name
    // Start is called before the first frame update
    void Start()
    {
        selector = FindObjectOfType<PlantSelector>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        WaveCompleted.text = "You completed " + spawner.wave + " waves!";
    }

    public void ReplayGame(int levelToLoad)
    {
        SaveWave();
        SceneManager.LoadScene(levelToLoad); // 0 for now, might change if we have more scenes
    }
    public void RepickPlants()
    {
        SaveWave();
        Destroy(selector); // deleting the selector so we dont have 2 in the selector scene
        SceneManager.LoadScene("PlantSelector"); // to open the plant selection screen
    }

    void SaveWave()
    {
        if(GameData.instance.waves < spawner.wave) // the waves we beat is bigger than our saved wave
        {
            GameData.instance.waves = spawner.wave;
        }

        for (int i = 0; i < GameData.instance.wavesCompleted.Length; i++) // loop through all of the saved completed waves
        {
            // A Note on how this all works. So if we keep return in it doesn't save properly so we can remove it
            // however, this way we now overwrite any spots under us. A way to get around this would be a swap algorithim
            // or we can brute force and save for each leaderboard position since there is only 5 (probably easier)
            if (spawner.wave > GameData.instance.wavesCompleted[i]) // if our wave is bigger
            {
                GameData.instance.wavesCompleted[i] = spawner.wave; // save the wave
                GameData.instance.playerNames[i] = nameField.text; // save the name
                GameData.instance.SaveData(); // save the games data
                return;
            }
        }

        //if(spawner.wave > GameData.instance.wavesCompleted[0]) // if the wave we beat is the best one we've done so far
        //{
        //    int tempWaves = GameData.instance.wavesCompleted[0]; // store the old data from that place
        //    string tempName = GameData.instance.playerNames[0]; // store the name
        //    GameData.instance.wavesCompleted[0] = spawner.wave; // put in our new details
        //    GameData.instance.playerNames[0] = nameField.text;
        //    if(tempWaves > GameData.instance.wavesCompleted[1])
        //    {
        //        int tempWaves2 = GameData.instance.wavesCompleted[1];
        //        string tempNames2 = GameData.instance.playerNames[1];

        //        GameData.instance.wavesCompleted[1] = tempWaves;
        //        GameData.instance.playerNames[1] = tempName;
        //    }
        //}

        GameData.instance.SaveData(); // save the games data
    }
}
