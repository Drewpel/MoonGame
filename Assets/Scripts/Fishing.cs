using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fishing : MonoBehaviour
{

    public Inventory inventory;
    public GameObject InteractUI;
    public Player_Controller player;
    private List<GameObject> ReelButtons;
    public GameObject ReelButtonsParent;
    public GameObject FishingUI;
    public Text FishCount;
    private float timer = 0f;
    private float nextFish = 0f;
    private bool fishing = false;
    private int fishCount = 0;
    private int totalfishCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        ReelButtons = new List<GameObject>();
        nextFish = Random.Range(3f, 10f);
        for (int i = 0; i < ReelButtonsParent.transform.childCount; i++)
        {
            ReelButtons.Add(ReelButtonsParent.transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!fishing) return;

        timer += Time.deltaTime;
        if (timer > nextFish)
        {
            timer = 0f;
            nextFish = Random.Range(3f, 10f);
            ReelButtons[Random.Range(0, ReelButtons.Count)].SetActive(true);
        }

        if (timer > 1f)
        {
            foreach (GameObject b in ReelButtons)
            {
                if (b.activeSelf) b.SetActive(false);
            }
        } 
    }

    public void GetFish()
    {
        foreach (GameObject b in ReelButtons)
        {
            if (b.activeSelf) b.SetActive(false);
        }
        totalfishCount++;
        fishCount++;
        FishCount.text = "+" + fishCount.ToString() + " Fish (" + totalfishCount + " Fish Total)";
        inventory.AddItem("Fish", 1);
        FindObjectOfType<Quests>().CompleteQuest(5);
    }

    public void Open()
    {
        FishCount.text = "+" + fishCount.ToString() + " Fish (" + totalfishCount + " Fish Total)";
        InteractUI.SetActive(false);
        player.StartInteracting();
        FishingUI.SetActive(true);
        fishing = true;
    }

    public void Close()
    {
        fishCount = 0;
        fishing = false;
        timer = 0f;
        FishingUI.SetActive(false);
        player.StopInteracting();
    }
}
