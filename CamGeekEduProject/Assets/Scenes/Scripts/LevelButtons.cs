using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButtons : MonoBehaviour 
{
    public Button LevelOneButton; // refs to button 1
    public Button LevelTwoButton; // refs to button 2

    private void Start()
    {
        LevelTwoButton.gameObject.SetActive(false);
        if(Gamemanager.instance.LevelsBeaten >= 1)
        {
            LevelTwoButton.gameObject.SetActive(true);
        }
    }
    public void LevelOne()
    {
        SceneManager.LoadScene(2);
    }
    public void LevelTwo()
    {
        SceneManager.LoadScene("Level2");
    }
}
