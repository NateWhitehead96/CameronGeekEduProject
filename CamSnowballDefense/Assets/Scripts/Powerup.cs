using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type // know what type of powerup we're collecting
{
    IncreaseShootSpeed,
    IncreaseSnowballSize,
    IncreaseHealth
}

public class Powerup : MonoBehaviour
{
    public Type type; // what type this powerup will be
    public float moveSpeed;
    private SpriteRenderer sprite; // this will help with changing the color of the powerup
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>(); // link the sprite variable to the spriterenderer on the gameobject
        int randomType = Random.Range(0, 3); // to pick a random type for our powerup

        if(randomType == 0) // if the first type is chosen
        {
            type = Type.IncreaseShootSpeed; // set type
            sprite.color = Color.green; // set color
        }
        if(randomType == 1) // if the second type is chosen
        {
            type = Type.IncreaseSnowballSize; // set type
            sprite.color = Color.blue; // set color
        }
        if(randomType == 2) // if the 3rd type is chosen
        {
            type = Type.IncreaseHealth; // set type
            sprite.color = Color.yellow; // set color
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y); // moving the powerup to the left

        if (transform.position.x < -12) // once the powerup is past our player and offscreen delete/destroy the powerup
        {
            Destroy(gameObject);
        }
    }
}
