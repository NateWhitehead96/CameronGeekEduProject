using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float bounds; // how high up or low the spawner can go
    public GameObject Enemy; // the enemy to spawn

    public float timer; // a variable that will count up
    public float SpawnTime = 2; // when we hit this time, spawn the enemy
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // increase timer

        if(timer >= SpawnTime) // once our timer hits the spawn time create a new enemy
        {
            float randomY = Random.Range(-bounds, bounds); // this is the new Y position for our spawner

            Instantiate(Enemy, new Vector3(transform.position.x, randomY), Quaternion.identity); // spawn the enemy at the new y position

            timer = 0; // reset timer
        }
    }
}
