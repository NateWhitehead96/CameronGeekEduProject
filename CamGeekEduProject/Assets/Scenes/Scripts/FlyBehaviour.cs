using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBehaviour : MonoBehaviour
{
    public float moveSpeed;
    public int Direction; // will tell us if the fly should go up or down
    public float TopPosition;
    public float BotPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > TopPosition) // changing direction to go down
        {
            Direction = -1;
        }
        if(transform.position.y < BotPosition) // changing direction to go up
        {
            Direction = 1;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y + Direction * moveSpeed * Time.deltaTime); // applying our direction and move speed to our position
    }
}
