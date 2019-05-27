using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Stats : MonoBehaviour
{

    public int health = 100;
    public int hunger = 100;
    public int thirst = 100;

    private float hungerTimer = 0;
    private float thirstTimer = 0;

    public Text HungerText;
    public Text ThirstText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        thirstTimer += Time.deltaTime;
        hungerTimer += Time.deltaTime;

        if (hungerTimer > 20)
        {
            hungerTimer = 0;
            SetHunger(hunger - 1);
        }

        if (thirstTimer > 30)
        {
            thirstTimer = 0;
            SetThirst(thirst - 1);
        }

        if (hunger < 1)
        {
            FindObjectOfType<Player_Controller>().Die("You died of starvation!");
        }
        else if (thirst < 1)
        {
            FindObjectOfType<Player_Controller>().Die("You died of dehydration!");
        }

    }

    public void Eat()
    {
        SetHunger(hunger + 10);
    }

    public void Drink()
    {
        SetThirst(thirst + 10);
    }

    public void SetHunger(int newHunger)
    {
        if (newHunger > 100) newHunger = 100;
        hunger = newHunger;
        HungerText.text = newHunger.ToString();
    }

    public void SetThirst(int newThirst)
    {
        if (newThirst > 100) newThirst = 100;
        thirst = newThirst;
        ThirstText.text = newThirst.ToString();
    }

}
