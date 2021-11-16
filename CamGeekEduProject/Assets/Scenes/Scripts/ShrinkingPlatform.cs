using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingPlatform : MonoBehaviour
{
    public bool Shrink = false;
    public float ShrinkAmount;
    public float OriginalSizeX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Shrink == true)
        {
            transform.localScale = new Vector3(transform.localScale.x - ShrinkAmount * Time.deltaTime, transform.localScale.y); // shrinking the platform
        }
        else
        {
            if(transform.localScale.x < OriginalSizeX)
            {
                transform.localScale = new Vector3(transform.localScale.x + ShrinkAmount * Time.deltaTime, transform.localScale.y); // growing the platform
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // our collision check to make sure player is landing on this platform
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Shrink = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision) // our collision check when the player leaves the platform
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Shrink = false;
        }
    }
}
