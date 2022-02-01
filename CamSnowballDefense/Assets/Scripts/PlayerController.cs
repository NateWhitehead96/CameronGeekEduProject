using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int moveSpeed; // how fast we travel
    public GameObject Snowball; // the snowball prefab
    public float bounds;

    public bool shooting; // tell us if we're shooting or not

    public float shootSpeed; // how fast we can shoot
    public float snowballSize; // how fat our snowballs are
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
        if (Input.GetMouseButtonDown(0) && shooting == false) // shooting the snowball
        {
            StartCoroutine(ShootSnowball()); // we can actually shoot 
        }
    }

    IEnumerator ShootSnowball()
    {
        shooting = true; // we're now shooting the snowball
        GameObject newSnowball = Instantiate(Snowball, transform.position, Quaternion.identity); // create a local variable so we can change things on the snowball
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // finding mouse position
        Vector3 shootDirection = mousePosition - transform.position; // find the vector between player and mouse
        newSnowball.GetComponent<SnowballScript>().MoveToPosition = new Vector3(shootDirection.x, shootDirection.y); // apply the movement to the snowball
        yield return new WaitForSeconds(1); // attack speed/shoot speed
        shooting = false; // flip shooting back off
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Powerup"))
        {
            Destroy(collision.gameObject); // to make sure the collision works
            //Powerup powerup = collision.gameObject.GetComponent<Powerup>(); // this is so we can access the powerup script from the collision

            //if(powerup.type == Type.IncreaseShootSpeed)
            //{
            //    shootSpeed -= 0.1f; // decrease the shoot cool down
            //}
        }
    }
}
