using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPlatform : MonoBehaviour
{
    [SerializeField]
    public float StartPosition; // how high is it, y position
    public float EndPosition; // stop it at this position
    public bool move = false; // true or false for if we move up
    public float moveSpeed; // how fast we move


    // Update is called once per frame
    void Update()
    {
        if(move == true && transform.position.y < EndPosition) // if we're on the platform lets move it up but not higher than our end position
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        }
        else
        {
            if(transform.position.y > StartPosition) // reset our elevator back to is original position
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // our collision check to make sure player is landing on this platform
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            move = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision) // our collision check when the player leaves the platform
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            move = false;
        }
    }
}
