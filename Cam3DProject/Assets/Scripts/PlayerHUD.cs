using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // give us access to text objects
using UnityEngine.SceneManagement; // to help to know what scene we're in

public class PlayerHUD : MonoBehaviour
{
    // ui variables
    public Text coinCounter;
    public Text livesCounter;
    public Text healthCounter;
    public Player player; // access to player
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>(); // link the player to our player
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("HUBWorld")) return; // if we're in the hub world, dont update texts

        coinCounter.text = "Coins: " + player.coins + " / " + FindObjectOfType<LevelExit>().coins; // display our coins
        livesCounter.text = "Lives: " + player.lives; // display our lives
        healthCounter.text = "Health: " + player.health + " / " + 5; // display health

        if(player.health <= 2) // turn the health text red when we're low health
        {
            healthCounter.color = Color.red;
        }
    }
}
