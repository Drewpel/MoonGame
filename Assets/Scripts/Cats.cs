using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cats : MonoBehaviour
{
    public Inventory inventory;
    public bool cat1fed = false;
    public bool cat2fed = false;

    public void FeedCat (int cat)
    {

        if (inventory.TakeSome("Fish", 2) == 2)
        {
            if (cat == 1)
            {
                cat1fed = true;
            }
            else if (cat == 2)
            {
                cat2fed = true;
            }

            if (cat1fed && cat2fed)
            {
                FindObjectOfType<Quests>().CompleteQuest(6);
            }
            FindObjectOfType<InteractableUI>().ShowInteractable("Cat " + cat.ToString(), "Now thats a happy cat :)", "", "", null, null);
        }
        else
        {
            FindObjectOfType<InteractableUI>().ShowInteractable("Cat " + cat.ToString(), "Darn. You need some fish if you're gunna do that!", "", "", null, null);
        }

    }
}
