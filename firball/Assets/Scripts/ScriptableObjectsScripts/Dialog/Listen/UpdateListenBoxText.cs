using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;


// Updates which speech to render (input based), as well as animates the speech (frame based)
public class UpdateListenBoxText : MonoBehaviour
{
    // This code assumes speeches saved in a dialog are not modefied in any way, ex removed or added
    public ListenBoxDisplay listenBoxDisplay;
    public Text speechText;
    public int timeSinceLastSwitch; // Relative to time passed, increases by one for every deltaTime
    public int animationSpeed; // In frames
    public int shownCharacters;
    public string fullDialogText;

    public void UpdateCurrentSpeech()
    {
        fullDialogText = listenBoxDisplay.speech;
        shownCharacters = 0;
    }
    private void AnimateSpeech()
    {
        if (shownCharacters < fullDialogText.Length)
        {
            shownCharacters++;
        }
        if (shownCharacters > fullDialogText.Length)
        {
            shownCharacters = fullDialogText.Length;
        }
        speechText.text = fullDialogText.Substring(0, shownCharacters);
    }

    void Start()
    {
        // Getting relevant DialogBoxDisplay object, MUST BE FIRST
        listenBoxDisplay = GetComponent<ListenBoxDisplay>();

        // Animation
        animationSpeed = 3;
        shownCharacters = 0;
        timeSinceLastSwitch = 0;

        fullDialogText = listenBoxDisplay.speech;

        // Getting to the correct child (No cops please)
        Transform textBoxTransform = transform.Find("TextBox");
        if (textBoxTransform != null)
        {
            Transform listenTextTransform = textBoxTransform.Find("ListenBox");
            if (listenTextTransform != null)
            {
                speechText = listenTextTransform.GetComponent<Text>();

                if (listenBoxDisplay == null)
                {
                    Debug.LogError("listenBoxDisplay not found");
                }
            }
            else
            {
                Debug.Log("speechTextTransform is empty: " + listenTextTransform);
            }
        }
        else
        {
            Debug.Log("TextTransform is empty: " + textBoxTransform);
        }

        if (listenBoxDisplay == null)
        {
            Debug.LogError("listenBoxDisplay not found!");
        }
    }

    void FixedUpdate()
    {
        if (timeSinceLastSwitch > animationSpeed) // Time so laggy players don't get stuck in dialog or get slower dialog
        {
            AnimateSpeech();
            timeSinceLastSwitch = 0;
        }
        timeSinceLastSwitch++;
    }
}
