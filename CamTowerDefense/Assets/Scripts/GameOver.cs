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
            if(spawner.wave > GameData.instance.wavesCompleted[i]) // if our wave is bigger
            {
                GameData.instance.wavesCompleted[i] = spawner.wave; // save the wave
                GameData.instance.playerNames[i] = nameField.text; // save the name
                return;
            }
        }

        GameData.instance.SaveData(); // save the games data
    }
}
