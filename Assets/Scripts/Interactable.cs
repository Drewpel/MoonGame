using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent immediateAction;
    public UnityEvent action1;
    public UnityEvent action2;

    public string iTitle = "";
    public string iText = "";
    public string iButton1 = "";
    public string iButton2 = "";

    public void Interact()
    {
        Debug.Log(immediateAction);
        if (immediateAction != null && immediateAction.GetPersistentEventCount() > 0) immediateAction.Invoke();
        else FindObjectOfType<InteractableUI>().ShowInteractable(iTitle, iText, iButton1, iButton2, action1, action2);
    }

}
