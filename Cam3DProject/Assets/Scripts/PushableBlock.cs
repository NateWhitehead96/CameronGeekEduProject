using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableBlock : MonoBehaviour
{
    public Vector3 initialPosition;
    public bool onPad; // optional, for my puzzle. when the block is on a triggerpad
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position; // set a start position
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Deathplane"))
        {
            transform.position = initialPosition; // if the block ever falls out of the bounds, respawn it
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            onPad = true;
            print("working");
        }
    }
}
