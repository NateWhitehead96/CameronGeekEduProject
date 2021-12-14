using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingHazard : MonoBehaviour
{
    public int Direction = 1;
    public float xMin; // lefthand side
    public float xMax; // righthand side
    public float speed; // how fast it can move
    
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + Direction * speed * Time.deltaTime, transform.position.y);

        if(transform.position.x < xMin)
        {
            Direction = 1;
        }
        if(transform.position.x > xMax)
        {
            Direction = -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // this will be rewritten next class and call a player function that will reset its position
            collision.gameObject.GetComponent<PlayerControl>().transform.position = collision.gameObject.GetComponent<PlayerControl>().CheckpointPosition; // when the player hits the hazard set player pos to checkpoint pos
        }
    }
}
