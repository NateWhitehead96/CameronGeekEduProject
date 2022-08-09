using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed; // how fast the coin rotates
    public float moveSpeed;// how fast it goes up and down
    public float top, bottom; // bounds for the bouncing
    public int direction = 1; // direction of the movement
    // Start is called before the first frame update
    void Start()
    {
        // assign top and bot with code
        top = transform.position.y + 0.5f;
        bottom = transform.position.y - 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime); // rotate the coin
        transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * direction * Time.deltaTime, transform.position.z);
        if(transform.position.y > top)
        {
            direction = -1;
        }
        if(transform.position.y < bottom)
        {
            direction = 1;
        }
    }
}
