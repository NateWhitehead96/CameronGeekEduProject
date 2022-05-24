using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockPlants : MonoBehaviour
{
    public GameObject[] selectablePlants; // all of the button in our scene that allow us to pick plants
    // Start is called before the first frame update
    void Awake()
    {
        GameData.instance.LoadData(); // load how many waves we've completed
        for (int i = 0; i < selectablePlants.Length; i++)
        {
            selectablePlants[i].GetComponent<Button>().interactable = false; // this makes all of the plants not interactable
            selectablePlants[i].GetComponent<Image>().color = Color.black;
        }

        if(GameData.instance.waves >= 0) // activate the basic plants
        {
            selectablePlants[0].GetComponent<Button>().interactable = true; // Sunflower
            selectablePlants[0].GetComponent<Image>().color = Color.white;
            selectablePlants[1].GetComponent<Button>().interactable = true; // Walnut
            selectablePlants[1].GetComponent<Image>().color = Color.white;
            selectablePlants[2].GetComponent<Button>().interactable = true; // Peashooter
            selectablePlants[2].GetComponent<Image>().color = Color.white;
            selectablePlants[3].GetComponent<Button>().interactable = true; // Potatomine
            selectablePlants[3].GetComponent<Image>().color = Color.white;
        }
        if(GameData.instance.waves >= 5) // completed 5 waves before, now can access banana and cherry
        {
            selectablePlants[4].GetComponent<Button>().interactable = true; // Banana
            selectablePlants[4].GetComponent<Image>().color = Color.white;
            selectablePlants[5].GetComponent<Button>().interactable = true; // Cherry
            selectablePlants[5].GetComponent<Image>().color = Color.white;
        }
        if(GameData.instance.waves >= 10)
        {
            selectablePlants[6].GetComponent<Button>().interactable = true; // Cactus
            selectablePlants[6].GetComponent<Image>().color = Color.white;
            selectablePlants[7].GetComponent<Button>().interactable = true; // Chickpea/Hen
            selectablePlants[7].GetComponent<Image>().color = Color.white;
        }
        if(GameData.instance.waves >= 15)
        {
            selectablePlants[8].GetComponent<Button>().interactable = true; // Speedshooter
            selectablePlants[8].GetComponent<Image>().color = Color.white;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
