using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyTracker : MonoBehaviour
{

    public List<GameObject> Flies;
    public int CurrentLevel;

    // Start is called before the first frame update
    void Start()
    {
        if(CurrentLevel == 1) // loading for level one
        {
            for (int i = 0; i < Flies.Count; i++)
            {
                Flies[i].GetComponent<FlyBehaviour>().Collected = Gamemanager.instance.LevelOneFlies[i];
            }
        }
        if(CurrentLevel == 2) // loading for level 2
        {
            for (int i = 0; i < Flies.Count; i++)
            {
                Flies[i].GetComponent<FlyBehaviour>().Collected = Gamemanager.instance.LevelTwoFlies[i];
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Flies.Count; i++)
        {
            if (Flies[i].GetComponent<FlyBehaviour>().Collected) // if the fly is collected make it invisible
            {
                Flies[i].SetActive(false);
            }
        }
    }

    public void SaveCollectedFlies(int level) // this will save all of the collected flies into our game manager
    {
        if(level == 1)
        {
            for (int i = 0; i < Flies.Count; i++)
            {
                Gamemanager.instance.LevelOneFlies[i] = Flies[i].GetComponent<FlyBehaviour>().Collected;
            }
        }
        if(level == 2)
        {
            for (int i = 0; i < Flies.Count; i++)
            {
                Gamemanager.instance.LevelTwoFlies[i] = Flies[i].GetComponent<FlyBehaviour>().Collected;
            }
        }
    }
}
