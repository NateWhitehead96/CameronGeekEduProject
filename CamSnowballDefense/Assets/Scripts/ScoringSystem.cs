using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public Text ScoreDisplay; // the text object on the screen
    public static int score; // the score will be static for this whole level so other scripts can edit this value easily
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreDisplay.text = score.ToString(); // the text will display the score;
    }
}
