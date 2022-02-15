using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public static ScoreKeeper instance; // the live link to the score keeper
    public int score; // our score
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject); // if there is a 2nd version of score keeper, delete it
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // this allows the score keeper to go between scenes
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
