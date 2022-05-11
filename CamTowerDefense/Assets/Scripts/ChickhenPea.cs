using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickhenPea : MonoBehaviour
{
    public Building self; // to help with increaseing health when the ckick part evolves
    public SpriteRenderer sprite; // to help with putting the hen sprite on this gameobject
    public Sprite henSprite;
    public float timer;
    public float reloadSpeed;
    public float evoTimer; // time it takes to evolve
    public GameObject pea; // the bullet pea to shoot
    // Start is called before the first frame update
    void Start()
    {
        self = GetComponent<Building>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        evoTimer -= Time.deltaTime; 
        if(evoTimer <= 0) // evolve the chicken
        {
            self.health += 3; // increase max hp
            reloadSpeed = 2; // lower reload speed
            sprite.sprite = henSprite; // change the sprite
        }
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Instantiate(pea, transform.position, transform.rotation);
            timer = reloadSpeed;
        }
    }
}
