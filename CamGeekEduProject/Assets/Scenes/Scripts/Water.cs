using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Water : MonoBehaviour
{
    public Transform respawnLocation;
        void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            FindObjectOfType<PlayerControl>().transform.position = respawnLocation.position;
        }
    }

}
