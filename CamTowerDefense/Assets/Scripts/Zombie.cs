using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float moveSpeed;
    public int health;

    public Building plantWereAttacking; // hold the plant we want to deal damage to
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<ZombieSpawner>().remainderEnemies++;
        SoundEffectManager.instance.zombieSpawn.Play(); // play the sound effect
        health += FindObjectOfType<ZombieSpawner>().wave; // buff zombie health by wave number
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        
        if(health <= 0)
        {
            FindObjectOfType<ZombieSpawner>().UpdateEnemiesRemaining();
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision) // for collision with the peas
    {
        if (collision.gameObject.CompareTag("Pea"))
        {
            health--;
            Destroy(collision.gameObject); // destroy the pea
            //if(health <= 0)
            //{
            //    Destroy(gameObject);
            //}
        }
        if (collision.gameObject.GetComponent<Building>()) // if the zombie collides with the plant
        {
            moveSpeed = 0; // stop the zombie from moving
            plantWereAttacking = collision.gameObject.GetComponent<Building>(); // know what plant the zombie is colliding with
            InvokeRepeating("DamagePlant", 1, 1); // it will constantly call the "DamagePlant" function every second
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Building>())
        {
            moveSpeed = 1; // reset movespeed
            if (plantWereAttacking != null)
            {
                plantWereAttacking = null; // make sure no memory leaks and reset this variable
                CancelInvoke("DamagePlant"); // make sure it stops attacking
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) // colliding with the plant buildings
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            moveSpeed = 0.2f; // stops moving when in contact with another zombie
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            moveSpeed = 1; // when its stopped touching the zombie, it can move
        }
    }

    void DamagePlant()
    {
        plantWereAttacking.health--;
        if(plantWereAttacking.health <= 0)
        {
            plantWereAttacking.tile.isOccupied = false; // free up that tile space for a new building/plant
            Destroy(plantWereAttacking.gameObject);
            moveSpeed = 1; // reapply some move speed after they kill a plant
            CancelInvoke(); // stop the damagin plant invoke
        }
    }
}
