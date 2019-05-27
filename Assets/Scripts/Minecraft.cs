using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minecraft : MonoBehaviour
{

    public GameObject MinecraftUI;
    public GameObject InteractUI;
    public Player_Controller player;
    public Text HappyStatus1;
    public Text HappyStatus2;
    public Text ChunkerStatus;

    private int happiness = 100;

    private float chunkerTimer = 0f;
    private float happyTimer = 0f;

    private string[] chunkerStatuses = { "Under Control", "Lagging Server", "Have Server-chan Hostage :(" };
    private int cIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        happyTimer += Time.deltaTime;
        chunkerTimer += Time.deltaTime;

        if (happyTimer > 7f)
        {
            happiness = Mathf.Max(0, happiness - 1);
            UpdateHappiness();
            happyTimer = 0f;
        }

        if (chunkerTimer > 30f)
        {
            cIndex = Random.Range(0, 3);
            if (cIndex > 0) happiness = Mathf.Max(0, happiness - (20 * cIndex));
            else if (cIndex == 0) happiness = Mathf.Min(100, happiness + 10);
            UpdateChunkerStatus();
            UpdateHappiness();
            chunkerTimer = 0f;
        }
    }

    public void BanChunkers()
    {
        cIndex = 0;
        happiness = Mathf.Min(100, happiness + 20);
        UpdateChunkerStatus();
        UpdateHappiness();
        chunkerTimer = 0f;
        FindObjectOfType<Quests>().CompleteQuest(7);
    }

    public void UpdateChunkerStatus()
    {
        ChunkerStatus.text = chunkerStatuses[cIndex];
    }

    public void UpdateHappiness()
    {
        HappyStatus1.text = happiness.ToString();
        HappyStatus2.text = happiness.ToString();
    }

    public void PlayerWithSubs()
    {
        happiness = 100;
        UpdateHappiness();
    }

    public void RestartServer()
    {
        happiness = Mathf.Min(100, happiness + 10);
        UpdateHappiness();
    }

    public void NewWorld()
    {
        happiness = Mathf.Max(0, happiness - 30);
        UpdateHappiness();
    }

    public void Open()
    {
        InteractUI.SetActive(false);
        player.StartInteracting();
        MinecraftUI.SetActive(true);
    }

    public void Close()
    {
        MinecraftUI.SetActive(false);
        player.StopInteracting();
    }
}
