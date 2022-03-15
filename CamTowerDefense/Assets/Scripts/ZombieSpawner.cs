using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject Zombie;
    public Transform[] SpawnPoints;

    public float StartTime; // the inital time it take before the zombies start spawning
    public float Timer; // help with spawning zombie at regular intervals

    public bool gameStart; // a bool to know when we should start spawning zombies
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
        if (gameStart == true) // only after the grace period will we start spawning zombies
        {
            if (Timer >= 10)
            {
                int randomPoint = Random.Range(0, SpawnPoints.Length); // find a random point to spawn the zombie at
                Instantiate(Zombie, SpawnPoints[randomPoint].position, transform.rotation); // spawn zombie
                Timer = 0; // reset timer
            }
            Timer += Time.deltaTime;
        }
    }
}
