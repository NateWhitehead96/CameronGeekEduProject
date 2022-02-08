using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject PauseCanvas; // pause canvas in our game scene

    private void Start()
    {
        PauseCanvas.SetActive(false); // make sure the pause canvas is not showing on game start
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (PauseCanvas.activeInHierarchy) // if the pause canvas is active
            {
                PauseCanvas.SetActive(false);
                Time.timeScale = 1;
            }
            else // canvas isnt on the screen
            {
                PauseCanvas.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
    [SerializeField]
    public void ResumeGame()
    {
        Time.timeScale = 1; // setting time to 1, or back to normal
        PauseCanvas.SetActive(false); // hide pause canvas
    }
}
