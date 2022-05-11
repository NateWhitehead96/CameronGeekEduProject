using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    public Zombie zombieToHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Zombie>())
        {
            zombieToHit = collision.gameObject.GetComponent<Zombie>(); // now the catus knows what zombie is hitting it
            InvokeRepeating("HurtZombie", 1, 1);
        }
    }

    public void HurtZombie()
    {
        zombieToHit.health--; // decrease the zombies health
        if(zombieToHit.health <= 0)
        {
            Destroy(zombieToHit.gameObject);
            zombieToHit = null; // clear it from all references
            CancelInvoke(); // stop doing this attack
        }
    }
}
