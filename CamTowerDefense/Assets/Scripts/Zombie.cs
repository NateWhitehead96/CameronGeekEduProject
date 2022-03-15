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
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);

    }
    
    private void OnTriggerEnter2D(Collider2D collision) // for collision with the peas
    {
        if (collision.gameObject.CompareTag("Pea"))
        {
            health--;
            Destroy(collision.gameObject); // destroy the pea
            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) // colliding with the plant buildings
    {
        if (collision.gameObject.GetComponent<Building>()) // if the zombie collides with the plant
        {
            plantWereAttacking = collision.gameObject.GetComponent<Building>(); // know what plant the zombie is colliding with
            InvokeRepeating("DamagePlant", 1, 1); // it will constantly call the "DamagePlant" function every second
        }
    }

    void DamagePlant()
    {
        plantWereAttacking.health--;
        if(plantWereAttacking.health <= 0)
        {
            plantWereAttacking.tile.isOccupied = false; // free up that tile space for a new building/plant
            Destroy(plantWereAttacking.gameObject);
            CancelInvoke(); // stop the damagin plant invoke
        }
    }
}
