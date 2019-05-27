using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public GameObject OptionsUI;

    public Slider volume;
    public Slider mouseSensitivity;
    public Slider TPCS;

    public AudioSource music;
    public Player_Controller player;

    public bool open = false;
    private bool playerIsInteracting = false;

    // Start is called before the first frame update
    void Start()
    {
        SetMouseSensitivity();
        SetVolume();
        SetTPCSensitivity();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetMouseSensitivity()
    {
        player.mouseSensitivity = mouseSensitivity.value;
    }

    public void SetTPCSensitivity()
    {
        player.optCamSpeed = TPCS.value;
    }

    public void SetVolume()
    {
        Debug.Log(volume.value);
        music.volume = volume.value;
    }

    public void Open()
    {
        open = true;
        if (player.isInteracting) playerIsInteracting = true;
        else player.StartInteracting();
        OptionsUI.SetActive(true);
    }

    public void Close()
    {
        open = false;
        if (playerIsInteracting) playerIsInteracting = false;
        else player.StopInteracting();
        OptionsUI.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
