using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InteractableUI : MonoBehaviour
{
    public Player_Controller player;

    public GameObject IPanel;
    public Text ITitle;
    public Text IText;
    public Button IButton1;
    public Text IButton1Text;
    public Button IButton2;
    public Text IButton2Text;
    public Button IButton3;
    public Text IButton3Text;

    public void ShowInteractable(string title, string text, string b1, string b2, UnityEvent action1, UnityEvent action2)
    {

        ITitle.text = title;
        IText.text = text;
        if (b1.Length > 0 && action1 != null)
        {
            IButton1.gameObject.SetActive(true);
            IButton1.onClick.RemoveAllListeners();
            IButton1.onClick.AddListener(action1.Invoke);
            IButton1Text.text = b1;
        }
        else
        {
            IButton1.gameObject.SetActive(false);
        }

        if (b2.Length > 0 && action2 != null)
        {
            IButton2.gameObject.SetActive(true);
            IButton2.onClick.RemoveAllListeners();
            IButton2.onClick.AddListener(action2.Invoke);
            IButton2Text.text = b2;
        }
        else
        {
            IButton2.gameObject.SetActive(false);
        }

        IPanel.gameObject.SetActive(true);
        player.StartInteracting();
    }

    public void Close()
    {
        IPanel.gameObject.SetActive(false);
        if (!FindObjectOfType<Quests>().QuestUI.activeSelf) player.StopInteracting();
    }

}
