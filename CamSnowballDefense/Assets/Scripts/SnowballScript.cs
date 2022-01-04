using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballScript : MonoBehaviour
{
    public int moveSpeed;
    public float bounds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y); // this will move the snowball towards the right
        if(transform.position.x > bounds) // when the snowball goes off screen, destroy the snowball
        {
            Destroy(gameObject);
        }
    }
}
