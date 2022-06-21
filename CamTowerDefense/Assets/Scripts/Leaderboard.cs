using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public Text[] CurrentLeaders;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < CurrentLeaders.Length; i++) // loop through all the saved leaders and load that data
        {
            CurrentLeaders[i].text = GameData.instance.playerNames[i] + " has beaten " + GameData.instance.wavesCompleted[i] + " waves.";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
