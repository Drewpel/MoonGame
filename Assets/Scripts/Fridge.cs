using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fridge : MonoBehaviour
{
    public GameObject FridgeUI;
    public Player_Controller player;
    public Player_Stats stats;
    public Inventory inventory;
    public Text SnackCount;
    public Text DrinkCount;
    public int snacks = 0;
    public int drinks = 0;

    public void GetSnack()
    {
        if (snacks > 0)
        {
            stats.Eat();
            snacks--;
            UpdateSnackCount();
        }
    }

    public void GetDrink()
    {
        if (drinks > 0)
        {
            stats.Drink();
            drinks--;
            UpdateDrinkCount();
        }
    }

    public void Open()
    {
        FridgeUI.SetActive(true);
        player.StartInteracting();
    }

    public void Close()
    {
        FridgeUI.SetActive(false);
        if (!FindObjectOfType<Quests>().QuestUI.activeSelf) player.StopInteracting();
    }

    public void StoreAll()
    {
        FindObjectOfType<Quests>().CompleteQuest(1);
        snacks += inventory.TakeAll("Berries");
        UpdateSnackCount();
        drinks += inventory.TakeAll("Water");
        UpdateDrinkCount();
    }

    private void UpdateSnackCount()
    {
        SnackCount.text = snacks.ToString();
    }

    private void UpdateDrinkCount()
    {
        DrinkCount.text = drinks.ToString();
    }

}
