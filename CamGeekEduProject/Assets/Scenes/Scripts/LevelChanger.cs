using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public int nextLevel; // this is the current level we're beating
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(nextLevel > Gamemanager.instance.LevelsBeaten)
            {
                Gamemanager.instance.LevelsBeaten++;
            }

            FindObjectOfType<FlyTracker>().SaveCollectedFlies(nextLevel); // to save our flies

            Gamemanager.instance.SaveData(); // we're saving our data everytime we beat a level
            
            SceneManager.LoadScene("LevelSelect");
        }
    }
}
