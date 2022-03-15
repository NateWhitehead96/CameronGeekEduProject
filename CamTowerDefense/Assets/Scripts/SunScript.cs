using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour
{
    public int increaseSunAmount; // how much currency we get when we collect the sun
    public float moveSpeed; // how fast it moves on screen
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime); // slowly move the sun down
        if(transform.position.y <= -6)
        {
            FindObjectOfType<GameManager>().suns += increaseSunAmount; // increase sun amount when the sun goes off screen
            Destroy(gameObject); // when the sun falls off screen, destroy
        }
    }
}
