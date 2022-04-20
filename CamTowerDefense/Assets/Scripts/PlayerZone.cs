using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerZone : MonoBehaviour
{
    public GameObject GameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        GameOverCanvas.SetActive(false);
        Time.timeScale = 1; // when we start this level make sure it's unpaused
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Zombie>())
        {
            Time.timeScale = 0; // pause game
            GameOverCanvas.SetActive(true); // show our canvas
        }
    }
}
