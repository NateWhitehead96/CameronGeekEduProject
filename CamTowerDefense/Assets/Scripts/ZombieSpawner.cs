using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject[] Zombie;
    public Transform[] SpawnPoints;

    public float StartTime; // the inital time it take before the zombies start spawning
    public float Timer; // help with spawning zombie at regular intervals

    public bool gameStart; // a bool to know when we should start spawning zombies
    public int numberOfEnemies; // how many zombies are we spawning per round
    public int wave; // what round/wave we're on
    public int waveDelay; // how much time to wait between waves

    public Text WaveText; // display the wave we're on
    public Text EnemiesRemainingText; // display on how many zombies are left
    public int remainderEnemies;

    public Animator incWaveAlert; // access to incoming wave animator
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GracePeriod());
    }

    IEnumerator GracePeriod()
    {
        yield return new WaitForSeconds(10); // the inital wait
        gameStart = true; // after waiting we can start spawning zombies
    }

    // Update is called once per frame
    void Update()
    {
        WaveText.text = "Wave: " + wave.ToString(); // update the wave counter
        EnemiesRemainingText.text = "Zombies: " + remainderEnemies.ToString();

        if (gameStart == true) // only after the grace period will we start spawning zombies
        {
            if (Timer >= 1 && numberOfEnemies > 0) // still have enemies to spawn
            {
                int randomPoint = Random.Range(0, SpawnPoints.Length); // find a random point to spawn the zombie at
                int randomZombie = Random.Range(0, Zombie.Length); // find a random zombie from the zombie list to spawn
                Instantiate(Zombie[randomZombie], SpawnPoints[randomPoint].position, transform.rotation); // spawn zombie
                Timer = 0; // reset timer
                numberOfEnemies--; // subtract one
            }
            if(numberOfEnemies <= 0)
            {
                StartCoroutine(StartNextWave());
            }
            Timer += Time.deltaTime;
        }
    }

    IEnumerator StartNextWave()
    {
        gameStart = false; // stop the spawning
        waveDelay = 30; // increase our wait by 10 seconds every wave
        yield return new WaitForSeconds(waveDelay);
        incWaveAlert.SetBool("incoming", true);
        yield return new WaitForSeconds(1); // delay for animation
        incWaveAlert.SetBool("incoming", false);
        wave++; // increase our wave
        numberOfEnemies = wave * 3; // 3 times the wave number of enemies will spawn
        gameStart = true; // restart the spawning process
    }

    public void UpdateEnemiesRemaining() // update the text and show how many zombies are left
    {
        remainderEnemies--; // subtract 1 enemy
        EnemiesRemainingText.text = "Zombies: " + remainderEnemies.ToString();
    }
}
