using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float bounds; // how high up or low the spawner can go
    public GameObject Enemy; // the enemy to spawn
    public GameObject Powerups; // the powerup to spawn

    public float timer; // a variable that will count up
    public float SpawnTime = 2; // when we hit this time, spawn the enemy

    public int NumberOfEnemies; // how many enemies in every wave
    // Start is called before the first frame update
    void Start()
    {
        NumberOfEnemies = 3;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // increase timer

        if(timer >= SpawnTime && NumberOfEnemies > 0) // once our timer hits the spawn time create a new enemy
        {
            float randomY = Random.Range(-bounds, bounds); // this is the new Y position for our spawner

            int randomChance = Random.Range(0, 5); // 1 in 5 chance to spawn the powerup instead of an enemy

            if(randomChance == 0)
            {
                Instantiate(Powerups, new Vector3(transform.position.x, randomY), transform.rotation); // spawn a power up
            }
            else
            {
                Instantiate(Enemy, new Vector3(transform.position.x, randomY), Quaternion.identity); // spawn the enemy at the new y position
                NumberOfEnemies--; // decrease the number of remaining enemies to spawn
            }
            timer = 0; // reset timer
            if(NumberOfEnemies <= 0)
            {
                StartCoroutine(NextWave()); // a small coroutine to delay next wave
            }
        }
    }

    IEnumerator NextWave()
    {
        yield return new WaitForSeconds(5); // delay for 5 seconds
        ScoringSystem.currentWave++; // increase the wave
        NumberOfEnemies += ScoringSystem.currentWave * 3; // set the number of enemies for this wave

        if(SpawnTime > 0.2f) // adjust the spawn time speed to have enemies spawn faster at higher waves
        {
            SpawnTime -= 0.1f;
        }
    }
}
