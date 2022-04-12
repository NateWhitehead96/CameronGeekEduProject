using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text WaveCompleted; // help display how many waves you beat
    public ZombieSpawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WaveCompleted.text = "You completed " + spawner.wave + " waves!";
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(0); // 0 for now, might change if we have more scenes
    }
}
