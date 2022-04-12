using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoMine : MonoBehaviour
{
    public Building self; // this is so we can reopen the tile it's placed
    public LayerMask zombieLayer; // a layer that all of the zombies will be on, so we know which zombies to kill when the mine blows up
    public float timer; // count how long it's been alive
    // Start is called before the first frame update
    void Start()
    {
        self = GetComponent<Building>(); // assign self to the building component on the mine
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Zombie") && timer >= 3) // when a zombie touches the mine
        {
            Collider2D[] zombiesInRange = Physics2D.OverlapCircleAll(transform.position, 2, zombieLayer); // finding all zombies in blast radius
            for (int i = 0; i < zombiesInRange.Length; i++) // loop through all the zombies and deal damage
            {
                zombiesInRange[i].gameObject.GetComponent<Zombie>().health -= 3;
            }
            self.tile.isOccupied = false; // opens up the tile
            Destroy(gameObject); // destroy the potato mine
        }
    }
}
