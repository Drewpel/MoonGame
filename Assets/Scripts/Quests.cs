using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quests : MonoBehaviour
{
    public Player_Controller player;
    public GameObject QuestUI;
    public Text questLabel;
    public Text questText;
    public List<Text> questTexts;
    public List<string> quests;
    private bool[] complete;
    private bool playerIsInteracting = false;
    private bool gameComplete = false;

    void Start()
    {
        questText.GetComponent<Outline>().effectColor = Color.blue;
        complete = new bool[quests.Count];
        for (int i = 0; i < complete.Length; i++)
        {
            complete[i] = false;
        }
    }

    public void CompleteQuest(int index)
    {
        if (complete[index]) return;
        complete[index] = true;
        questText.text = quests[index];
        questTexts[index].color = Color.green;
        Open();
    }

    public void Open()
    {
        if (player.isInteracting) playerIsInteracting = true;
        else player.StartInteracting();
        QuestUI.SetActive(true);
    }

    public void Close()
    {
        if (playerIsInteracting) playerIsInteracting = false;
        else player.StopInteracting();
        QuestUI.SetActive(false);

        if (gameComplete) return;

        bool gameover = true;
        for (int i = 0; i < complete.Length - 1; i++)
        {
            if (!complete[i]) gameover = false;
        }
        if (gameover) CompleteGame();
    }

    public void CompleteGame()
    {
        gameComplete = true;
        questLabel.text = "";
        questText.text = "You Completed The Game!" + System.Environment.NewLine + "Nice job man thats pretty good.";
        Open();
    }

}
