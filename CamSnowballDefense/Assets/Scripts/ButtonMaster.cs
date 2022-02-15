using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMaster : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene"); // open up our play scene
    }

    public void OpenControls()
    {
        SceneManager.LoadScene("Controls"); // open up our control scene
    }

    public void ExitGame()
    {
        Application.Quit(); // close the game
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // open up our main menu scene
    }
}
