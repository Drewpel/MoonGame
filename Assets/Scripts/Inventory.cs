using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public class MoonItem
    {
        public string name;
        public int count;

        public MoonItem(string itemName, int itemCount)
        {
            name = itemName;
            count = itemCount;
        }
    }

    public Text InventoryText;
    public List<MoonItem> inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new List<MoonItem>();
    }

    public void UpdateUI()
    {
        string inventoryString = "";
        foreach (MoonItem item in inventory)
        {
            inventoryString += (item.name + ": " + item.count.ToString() + "; ");
        }
        InventoryText.text = inventoryString;
    }

    public void AddItem(string itemName, int itemCount)
    {
        bool added = false;

        foreach (MoonItem item in inventory)
        {
            if (item.name == itemName)
            {
                added = true;
                item.count += itemCount;
            }
        }

        if (!added) inventory.Add(new MoonItem(itemName, itemCount));

        UpdateUI();
    }

    public void AddWater()
    {
        AddItem("Water", 1);
    }

    public int TakeAll(string itemName)
    {
        int count = 0;
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].name == itemName)
            {
                count = inventory[i].count;
                inventory.RemoveAt(i);
                break;
            }
        }
        UpdateUI();
        return count;
    }

    public int TakeSome(string itemName, int c)
    {
        int count = 0;
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].name == itemName)
            {
                if (inventory[i].count > c)
                {
                    inventory[i].count -= c;
                    count = c;
                }
                else if (inventory[i].count == c)
                {
                    count = c;
                    inventory.RemoveAt(i);
                }
                break;
            }
        }
        UpdateUI();
        return count;
    }

}
