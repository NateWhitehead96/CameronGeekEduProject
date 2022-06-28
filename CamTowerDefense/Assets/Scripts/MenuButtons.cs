using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("PlantSelector"); // load the plant selection screen
    }
    public void SettingButton()
    {
        SceneManager.LoadScene("Settings"); // load the setting screen
    }
    public void ExitButton()
    {
        Application.Quit(); // close the game, only works in a build version
    }
    public void LeaderboardButton()
    {
        SceneManager.LoadScene("LeaderBoard"); // open leaderboard scene
    }
}
