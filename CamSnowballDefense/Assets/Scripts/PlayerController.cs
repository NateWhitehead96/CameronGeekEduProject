using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int moveSpeed; // how fast we travel
    public GameObject Snowball; // the snowball prefab
    public float bounds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) && transform.position.y < bounds) // for moving up
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) && transform.position.y > -bounds) // for moving down
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space)) // shooting the snowball
        {
            // instantiate wants 3 things. the thing to spawn, the location, and the rotation
            Instantiate(Snowball, transform.position, Quaternion.identity);
        }
    }
}
