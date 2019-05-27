using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDialogue : MonoBehaviour
{

    public Inventory inventory;

    public void Part2()
    {
        FindObjectOfType<InteractableUI>().ShowInteractable("My Tesla", "You know, I'm actually saving the world by driving an electric car.", "", "", null, null);
    }

    public void WashCar()
    {
        if (inventory.TakeSome("Water", 3) == 3)
        {
            FindObjectOfType<InteractableUI>().ShowInteractable("My Tesla", "Nice job! You washed your Tesla! Looks great!", "", "", null, null);
            FindObjectOfType<Quests>().CompleteQuest(4);
        }
        else
        {
            FindObjectOfType<InteractableUI>().ShowInteractable("My Tesla", "Uh Oh :( You need 3 buckets of water to wash your car. Wonder where you could find some?", "", "", null, null);
        }
    }

}
