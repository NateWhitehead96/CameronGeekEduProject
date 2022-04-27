using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int suns; // currancy

    public Building plantToPlace; // the plant we want to place
    public CustomCursor customCursor; // access to the cursor

    public Tile[] tiles; // array (aka list) of our tiles

    public LayerMask sunlayer; // the layermask the suns are clickable on

    public Text SunDisplay; // the text that displays our sun amount

    // Loading plant types to our buttons variables
    public Building[] plants; // all of the different building/plants we can build
    public Button[] buttons; // all of the plant buttons
    public Text[] plantCosts; // of the plant costs
    public Sprite[] plantSprites; // hold all of the plant sprites for us
    // Start is called before the first frame update
    void Start()
    {
        customCursor.gameObject.SetActive(false); // to make sure the cursor is hidden when we dont have a building selected
        for (int i = 0; i < buttons.Length; i++) // loop through all buttons
        {
            int newPlant = Random.Range(0, plants.Length); // find us a new random plant to place on that button
            buttons[i].onClick.AddListener(delegate { BuyPlant(plants[newPlant]); }) ; // adds a on click event to the button
            buttons[i].GetComponent<Image>().sprite = plantSprites[newPlant]; // set the new image of the button
            plantCosts[i].text = plants[newPlant].cost.ToString(); // display the cost of the plant
        }
    }

    // Update is called once per frame
    void Update()
    {
        SunDisplay.text = suns.ToString();
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
                Building newPlant = Instantiate(plantToPlace, nearestTile.transform.position, Quaternion.identity); // spawn plant
                newPlant.tile = nearestTile; // set the tile of the plant to be the tile we place the plant on
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
        if(Input.GetMouseButtonDown(1) && plantToPlace != null) // when we right click and have a plant on our mouse
        {
            suns += plantToPlace.cost; // refund the cost of the plant
            plantToPlace = null; // take the plant off of our cursor
            Cursor.visible = true; // we can see the mouse
            customCursor.gameObject.SetActive(false); // hide the custom cursor
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
