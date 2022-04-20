using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : MonoBehaviour
{
    public GameObject PeaBullet; // prefab of the pea
    public float timer;
    public float reloadSpeed; // how often it can shoot
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime; // count down the timer
        if (timer <= 0)
        {
            Instantiate(PeaBullet, transform.position, transform.rotation); // spawn the bullet
            timer = reloadSpeed; // reset timer
        }
    }
}
