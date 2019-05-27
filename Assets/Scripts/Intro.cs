using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{

    public Text mainText;
    private float timer = 1000;
    public List<string> texts;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            timer += 3f;
            index = texts.Count - 2;
        }

        timer = timer + Time.deltaTime;

        if (timer > 3f || Input.GetKeyDown(KeyCode.Mouse0))
        {

            if (index == texts.Count)
            {
                SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
            }
            else
            {
                timer = 0f;
                mainText.text = texts[index];
                index++;
            }
        }

    }
}
