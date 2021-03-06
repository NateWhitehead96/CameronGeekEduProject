using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlantSelector : MonoBehaviour
{
    public List<Building> plantsChosen;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject); // makes sure this comes with us to the next scene
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectPlant(Building plant)
    {
        if(plantsChosen.Count < 4) // if we have less than 4 plants we can add this new one
            plantsChosen.Add(plant); // add the plant we clicked to our list of plants chosen

        for (int i = 0; i < plantsChosen.Count; i++)
        {
            print(plantsChosen[i].name); // hoping this prints something worth while
        }
    }

    public void PlayGame(int levelToLoad)
    {
        if(plantsChosen.Count == 4)
            SceneManager.LoadScene(levelToLoad); // load our game scene

        if (levelToLoad == 0)
        {
            SceneManager.LoadScene(levelToLoad);
            Destroy(gameObject); // to avoid having more selectors if we go to menu and back to playing
        }
    }
}
