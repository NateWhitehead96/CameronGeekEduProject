using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerScript : MonoBehaviour
{
    public GameObject Sun; // the prefab sun we spawn
    public float timer; // will keep track of when to spawn the sun
    public float SpawnSunTime; // the time it takes to spawn a sun
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime; // count down the timer
        if(timer <= 0)
        {
            Instantiate(Sun, transform.position, transform.rotation); // spawn the sun
            timer = SpawnSunTime; // reset timer
        }
    }
}
