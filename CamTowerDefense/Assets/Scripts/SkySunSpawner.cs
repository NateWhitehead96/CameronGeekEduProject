using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkySunSpawner : MonoBehaviour
{
    public GameObject sun; // the sun we're spawning
    public float timer;
    public float spawnSunTime;
    public float xPosition; // this will be a new x postion everytime the sky spawns a sun
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= spawnSunTime)
        {
            xPosition = Random.Range(-7, 7); // bounds of the screen
            transform.position = new Vector3(xPosition, transform.position.y); // apply the new xposition
            Instantiate(sun, transform.position, transform.rotation); // spawn sun
            timer = 0; // reset timer
        }
        timer += Time.deltaTime; // count timer up
    }
}
