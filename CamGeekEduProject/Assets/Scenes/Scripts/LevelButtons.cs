using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButtons : MonoBehaviour { 
public void LevelOne()
{
    SceneManager.LoadScene(2);
}
    public void LevelTwo()
    {
        SceneManager.LoadScene("Level2");
    }
}
