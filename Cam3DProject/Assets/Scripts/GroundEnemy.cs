using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // access to navigation stuff

public class GroundEnemy : MonoBehaviour
{
    public NavMeshAgent agent; // AI part of the enemy that moves it around
    public Vector3 destination; // where the AI will wonder to
    public float timer; // be a timer for when we want to move to a new destination
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0)
        {
            float x = Random.Range(transform.position.x - 10, transform.position.x + 10); // new random x position
            float z = Random.Range(transform.position.z - 10, transform.position.z + 10); // new random z position
            destination = new Vector3(x, transform.position.y, z); // set a new destination to move to
            agent.SetDestination(destination); // move the enemy
            timer = 5; // reset timer to 5
        }
        timer -= Time.deltaTime; // count down time
    }
}
