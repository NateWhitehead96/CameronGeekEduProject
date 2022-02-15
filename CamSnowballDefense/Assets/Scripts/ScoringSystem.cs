using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoringSystem : MonoBehaviour
{
    public Text ScoreDisplay; // the text object on the screen
    public static int score; // the score will be static for this whole level so other scripts can edit this value easily

    public Text LivesDisplay; // text to show lives
    public static int lives; // a global static variable for our lives

    public Text WaveDisplay; // text to show the current wave
    public static int currentWave; // our current wave
    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        currentWave = 1;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreDisplay.text = "Score: " + score; // the text will display the score;
        LivesDisplay.text = "Lives: " + lives; // display lives
        WaveDisplay.text = "Wave: " + currentWave; // display wave
        ScoreKeeper.instance.score = score; // any score we gain while playing is stored to our score keeper

        if(lives <= 0)
        {
            SceneManager.LoadScene("GameOver"); // loading the game over scene
        }
    }
}
