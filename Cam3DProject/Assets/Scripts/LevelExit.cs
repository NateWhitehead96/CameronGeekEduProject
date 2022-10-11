using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public Player player; // access to know how many coins they have
    public int coins; // how many coins are in the level
    public GameObject particleSystem; // turn on and off this particle system
    public MeshRenderer mesh; // body of the gameobject
    public SphereCollider collider;
    public int levelBeat; // to unlock the next level
    // Start is called before the first frame update
    void Start()
    {
        // hide all the things to start
        particleSystem.SetActive(false);
        mesh.enabled = false;
        collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.coins >= coins) // when player has collected enough coins
        {
            particleSystem.SetActive(true);
            mesh.enabled = true;
            collider.enabled = true;
        }
        transform.LookAt(player.transform); // make the level exit portal always look at our player
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            if(GameManager.instance.levelsBeaten < levelBeat)
            {
                GameManager.instance.levelsBeaten = levelBeat; // if we haven't beaten this level, set its value to levels beaten
                GameManager.instance.SaveGame(); // save data
            }
            SceneManager.LoadScene("HUBWorld");
        }
    }
}
