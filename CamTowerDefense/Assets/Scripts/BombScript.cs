using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum bombType
{
    cherry,
    banana
}

public class BombScript : MonoBehaviour
{
    public bombType type; // the type this bomb will be
    public Building self; // to reopen the tile after detonation
    public LayerMask zombieLayer; // the layer our zombies are in so we can deal damage to them
    // Start is called before the first frame update
    void Start()
    {
        self = GetComponent<Building>(); // assign self as the building
        if(type == bombType.cherry)
        {
            StartCoroutine(CherryBlast());
        }
    }

    IEnumerator CherryBlast()
    {
        yield return new WaitForSeconds(2);
        Collider2D[] zombiesInRange = Physics2D.OverlapCircleAll(transform.position, 2, zombieLayer);
        for (int i = 0; i < zombiesInRange.Length; i++)
        {
            zombiesInRange[i].gameObject.GetComponent<Zombie>().health -= 5;
        }
        self.tile.isOccupied = false;
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(type == bombType.banana)
        {
            if (collision.gameObject.CompareTag("Zombie"))
            {
                Collider2D[] zombieInRange = Physics2D.OverlapCircleAll(transform.position, 2, zombieLayer); // find all zombies in blast
                for (int i = 0; i < zombieInRange.Length; i++)
                {
                    zombieInRange[i].gameObject.GetComponent<Zombie>().health -= 1; // subtact 1 health
                    zombieInRange[i].gameObject.GetComponent<Zombie>().moveSpeed = 0.5f; // half the zombie move speed
                }
                self.tile.isOccupied = false;
                Destroy(gameObject);
            }
        }
    }
}
