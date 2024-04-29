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
    [SerializeField] ListenBoxDisplay listenBoxDisplay;
    [SerializeField] Text speechText;
    [SerializeField] int timeSinceLastSwitch; // Relative to time passed, increases by one for every deltaTime
    [SerializeField] int animationSpeed; // In frames
    [SerializeField] int shownCharacters;
    [SerializeField] string fullDialogText;

    public string GetFullDialogText()
    {
        return fullDialogText;
    }

    public void UpdateCurrentSpeech()
    {
        fullDialogText = listenBoxDisplay.GetSpeech();
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
        animationSpeed = 1;
        shownCharacters = 0;
        timeSinceLastSwitch = 0;

        fullDialogText = listenBoxDisplay.GetSpeech();

        // Getting to the correct child (No cops please)
        // Vet genuint inte varför jag inte bara la skriptet PÅ textObjektet direkt, men pallar inte göra om
        Transform listen = transform.Find("Listen");
        if (listen != null)
        {
            Transform textBoxTransform = listen.Find("TextBox");
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
        }
        else
        {
            Debug.Log("Listen does not exist: " + listen);
        }
        if (listenBoxDisplay == null)
        {
            Debug.LogError("listenBoxDisplay not found!");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shownCharacters = fullDialogText.Length;
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
