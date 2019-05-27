using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Streaming : MonoBehaviour
{

    public Player_Controller player;
    public Player_Stats stats;

    public GameObject InteractUI;
    public GameObject StreamingUI;
    public GameObject StreamOptions;
    public GameObject StreamResults;
    public Text gameChoice;
    public Text timeChoice;
    private string game = "OW";
    private int hours = 2;

    private string OVERWATCH = "OW";
    private string APEX_LEGENDS = "AL";
    private string IRL = "IRL";
    private string JUST_CHATTING = "JC";

    private int totalSubs = 0;
    private int totalFollows = 0;

    public Text Subscribers;
    public Text Followers;
    public Text NSubscribers;
    public Text NFollowers;
    public Text Status;

    public void StartStreaming()
    {
        StreamOptions.SetActive(false);
        StreamResults.SetActive(true);

        int subs = 0;
        for (int i = 0; i < hours; i++)
        {
            subs += Random.Range(-3, 15);
        }

        totalSubs += subs;
        NSubscribers.text = (subs < 0 ? "- " + subs.ToString() : "+ " + subs.ToString());
        Subscribers.text = totalSubs.ToString();

        int follows = 0;
        for (int i = 0; i < hours; i++)
        {
            follows += Random.Range(-10, 75);
        }

        totalFollows += follows;
        NFollowers.text = (follows < 0 ? "- " + follows.ToString() : "+ " + follows.ToString());
        Followers.text = totalFollows.ToString();

        stats.SetHunger(stats.hunger - (5 * hours));
        stats.SetThirst(stats.thirst - (7 * hours));

        if (stats.hunger < 1)
        {
            FindObjectOfType<Death>().EndGame("You died of starvation while streaming! D:");
        }
        else if (stats.thirst < 1)
        {
            FindObjectOfType<Death>().EndGame("You died of dehydration on stream! D:");
        }
        else 
        {
            if (totalSubs > 100)
            {
                FindObjectOfType<Quests>().CompleteQuest(3);
            }
            else if (totalFollows > 100)
            {
                FindObjectOfType<Quests>().CompleteQuest(2);
            }
        }

    }

    public void Open()
    {
        InteractUI.SetActive(false);
        StreamingUI.SetActive(true);
        StreamOptions.SetActive(true);
        StreamResults.SetActive(false);
        player.StartInteracting();
    }

    public void Close()
    {
        StreamingUI.SetActive(false);
        player.StopInteracting();
    }

    public void SetTime(int h)
    {
        hours = h;
        timeChoice.text = hours.ToString() + " Hours";
    }

    public void SetGameOverwatch()
    {
        game = OVERWATCH;
        gameChoice.text = "Overwatch";
    }

    public void SetGameApexLegends()
    {
        game = APEX_LEGENDS;
        gameChoice.text = "Apex Legends";
    }

    public void SetGameIRL()
    {
        game = IRL;
        gameChoice.text = "IRL";
    }

    public void SetGameJustChatting()
    {
        game = JUST_CHATTING;
        gameChoice.text = "Just Chatting";
    }

}
