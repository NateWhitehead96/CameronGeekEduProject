using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantButton : MonoBehaviour
{
    public Button self; // so the button references itself when we want to make it interactable
    public Building plant; // what plant type this button will be
    // Start is called before the first frame update
    void Start()
    {
        self = GetComponent<Button>();
        //self.interactable = true;
    }

    public void SelectedPlant()
    {
        if(FindObjectOfType<PlantSelector>().plantsChosen.Count <= 4)
        {
            self.interactable = false; // when the button is clicked it becomes not interactable any more
            gameObject.GetComponent<Image>().color = Color.green; // tint the selected plant
        }
    }

    public void BuyingCooldown()
    {
        if(plant.cost <= FindObjectOfType<GameManager>().suns) // only if we have the moolah do we make it cooldown
            StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        self.interactable = false;
        yield return new WaitForSeconds(2);
        self.interactable = true;
    }
}
