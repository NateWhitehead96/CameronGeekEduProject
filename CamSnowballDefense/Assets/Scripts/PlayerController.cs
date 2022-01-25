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
        if (Input.GetKey(KeyCode.W) && transform.position.y < bounds || Input.GetKey(KeyCode.UpArrow) && transform.position.y < bounds) // for moving up
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y > -bounds || Input.GetKey(KeyCode.DownArrow) && transform.position.y > -bounds) // for moving down
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        }
        if (Input.GetMouseButtonDown(0)) // shooting the snowball
        {
            ShootSnowball(); // we can actually shoot 
        }
    }

    void ShootSnowball()
    {
        GameObject newSnowball = Instantiate(Snowball, transform.position, Quaternion.identity); // create a local variable so we can change things on the snowball
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // finding mouse position
        Vector3 shootDirection = mousePosition - transform.position; // find the vector between player and mouse
        newSnowball.GetComponent<SnowballScript>().MoveToPosition = new Vector3(shootDirection.x, shootDirection.y); // apply the movement to the snowball
    }
}
