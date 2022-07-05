using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int cost;
    public int health;
    public Tile tile; // the tile the plant will be placed on

    public SpriteRenderer sprite; // access to the sprite so we can change it
    public Sprite hurtVersion; // the sprite of the plant when it's hurt
    public int halfHealth; // so we can compare health to this and know when to switch the sprite
    public bool hasOtherSprites; // a bool to check if we have hurt versions of this plant or not
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        halfHealth = health / 2; // make sure whatever our health is is also the starting health
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= halfHealth && hasOtherSprites == true)
        {
            sprite.sprite = hurtVersion; // change the sprite to be the hurt version
        }
    }
}
