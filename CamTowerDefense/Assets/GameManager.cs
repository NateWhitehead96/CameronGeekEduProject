using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int suns; // currancy

    public Building plantToPlace; // the plant we want to place
    public CustomCursor customCursor; // access to the cursor

    public Tile[] tiles; // array (aka list) of our tiles
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
            Tile nearestTile = null;
            float nearestDistance = float.MaxValue;
            // WE NEED TO RECODE THIS TOGETHER
            //foreach (Tile tile in tiles)
            //{
            //    float distance = Vector2.Distance(tile.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            //    if(distance < nearestDistance) // if our mouse is over a tile
            //    {
            //        nearestDistance = distance;
            //        nearestTile = tile;
            //    }
            //}
            //if(nearestTile.isOccupied == false) // that tile is not occupied then we spawn a plant
            //{
            //    Instantiate(plantToPlace, nearestTile.transform.position, Quaternion.identity);
            //    plantToPlace = null; // reset our plant to place
            //    nearestTile.isOccupied = true; // make sure that tile is now occupied
            //    Cursor.visible = true; // reshow our defualt cursor
            //    customCursor.gameObject.SetActive(false); // hide the custom cursor
            //}
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
