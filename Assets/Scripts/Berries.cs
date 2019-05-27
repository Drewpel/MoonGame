using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berries : MonoBehaviour
{
    private Inventory inventory;
    public GameObject berry1;
    public GameObject berry2;

    private bool hasBerries = true;
    private float berryTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasBerries)
        {
            berryTimer += Time.deltaTime;
            if (berryTimer > 120f)
            {
                berry1.SetActive(true);
                berry1.SetActive(true);
                hasBerries = true;
            }
        }
    }

    public void TakeBerries()
    {
        if (!hasBerries)
        {
            FindObjectOfType<InteractableUI>().ShowInteractable("Berry Bush", "Oh man, this bush is out of berries!", "", "", null, null);
            return;
        }
        inventory.AddItem("Berries", 2);
        berryTimer = 0f;
        berry1.SetActive(false);
        berry2.SetActive(false);
        hasBerries = false;
        FindObjectOfType<Quests>().CompleteQuest(0);
    }

}
