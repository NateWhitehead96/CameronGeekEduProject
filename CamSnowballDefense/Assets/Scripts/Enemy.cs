using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int moveSpeed;
    public Animator animator; // the animation controller for the enemy
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // set our animator to the animator on this gameobject
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y); // moving the enemy to the left

        if(transform.position.x < -12) // once the enemy is past our player and offscreen delete/destroy the enemy
        {
            ScoringSystem.lives--; // lose 1 life
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Snowball")) // the enemy gets hit by a snowball
        {
            ScoringSystem.score += 1; // add 1 to the score everytime we hit an enemy
            Destroy(collision.gameObject); // destroy snowball
            
            StartCoroutine(Dying());
        }
    }

    IEnumerator Dying()
    {
        animator.SetBool("dying", true); // activates the dying animation
        gameObject.GetComponent<BoxCollider2D>().enabled = false; // disable the collider
        moveSpeed = 0; // the enemy doesnt move anymore
        yield return new WaitForSeconds(2); // wait 2 seconds to allow the animation to play
        Destroy(gameObject); // destroy the enemy
    }
}
