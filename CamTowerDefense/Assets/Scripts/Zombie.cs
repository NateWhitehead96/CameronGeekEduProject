using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float moveSpeed;
    public int health;

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
}
