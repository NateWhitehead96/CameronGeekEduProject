using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int suns; // currancy

    public Building plantToPlace; // the plant we want to place
    public CustomCursor customCursor; // access to the cursor

    public Tile[] tiles; // array (aka list) of our tiles

    public LayerMask sunlayer; // the layermask the suns are clickable on
    // Start is called before the first frame update
    void Start()
    {
        customCursor.gameObject.SetActive(false); // to make sure the cursor is hidden when we dont have a building selected
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && plantToPlace != null) // placing plant
        {
            Tile nearestTile = null; // this tile will be the nearest tile to our left click
            float nearestDistance = float.MaxValue; // this is the nearest distance of that tile

            foreach (Tile tile in tiles) // loop through all of the tiles in our grid
            {    // find the distance from the tile we're looking at in the loop, and our mouse position
                float distance = Vector2.Distance(tile.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if (distance < nearestDistance) // if our mouse is over a tile
                {
                    nearestDistance = distance; // sets nearest distance to whatever is the lowest distance from a tile to our mouse pos
                    nearestTile = tile; // set the nearest tile to that tile thats closest to our mouse position
                }
            }
            if (nearestTile.isOccupied == false) // that tile is not occupied then we spawn a plant
            {
                Instantiate(plantToPlace, nearestTile.transform.position, Quaternion.identity); // spawn plant
                plantToPlace = null; // reset our plant to place
                nearestTile.isOccupied = true; // make sure that tile is now occupied
                Cursor.visible = true; // reshow our defualt cursor
                customCursor.gameObject.SetActive(false); // hide the custom cursor
            }
        }
        if(Input.GetMouseButtonDown(0) && plantToPlace == null)
        {// finding the thing we hit on our raycast, from our mouse position and interacting with the sun layer
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, Mathf.Infinity, sunlayer);

            if(hit.collider == null)
            {
                return; // if we click on nothing, stop doing the rest of the stuff
            }

            if (hit.collider.GetComponent<SunScript>())
            {
                suns += hit.collider.GetComponent<SunScript>().increaseSunAmount; // increase our suns
                Destroy(hit.collider.gameObject); // destroy the sun
            }
        }
    }

    public void BuyPlant(Building plant)
    {
        if(suns >= plant.cost)
        {
            customCursor.gameObject.SetActive(true); // make the cursor visible
            customCursor.GetComponent<SpriteRenderer>().sprite = plant.GetComponent<SpriteRenderer>().sprite; // set cursor to plant sprite
            Cursor.visible = false;

            suns -= plant.cost; // subtracting the cost
            plantToPlace = plant; // making sure the plant we want to place this the one we click on
        }
    }
}
