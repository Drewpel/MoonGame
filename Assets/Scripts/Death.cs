using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{

    public GameObject StreamingUI;
    public GameObject InteractUI;
    public GameObject DeathUI;
    public Text DeathMessage;

    public void EndGame(string dm)
    {
        StreamingUI.SetActive(false);
        InteractUI.SetActive(false);
        DeathUI.SetActive(true);
        DeathMessage.text = dm;
    }

    public void Reset()
    {
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
    }

}
