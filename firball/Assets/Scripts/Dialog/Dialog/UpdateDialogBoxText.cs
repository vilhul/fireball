using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;


// Updates which speech to render (input based), as well as animates the speech (frame based)
public class UpdateDialogBoxText : MonoBehaviour
{
    // This code assumes speeches saved in a dialog are not modified in any way, ex removed or added
    [SerializeField] DialogBoxDisplay dialogBoxDisplay;
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
        fullDialogText = dialogBoxDisplay.GetSpeech();
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
        dialogBoxDisplay = GetComponent<DialogBoxDisplay>();

        // Animation
        animationSpeed = 1;
        shownCharacters = 0;
        timeSinceLastSwitch = 0;

        fullDialogText = dialogBoxDisplay.GetSpeech();

        // Getting to the correct child (No cops please)
        // Vet genuint inte varför jag inte bara la skriptet PÅ textObjektet direkt, men pallar inte göra om
        Transform dialog = transform.Find("Listen");
        if (dialog != null)
        {
            Transform textBoxTransform = dialog.Find("TextBox");
            if (textBoxTransform != null)
            {
                Transform dialogTextTransform = textBoxTransform.Find("ListenBox");
                if (dialogTextTransform != null)
                {
                    speechText = dialogTextTransform.GetComponent<Text>();

                    if (dialogBoxDisplay == null)
                    {
                        Debug.LogError("dialogBoxDisplay not found");
                    }
                }
                else
                {
                    Debug.Log("speechTextTransform is empty: " + dialogTextTransform);
                }
            }
            else
            {
                Debug.Log("TextTransform is empty: " + textBoxTransform);
            }
        }
        else
        {
            Debug.Log("Dialog does not exist: " + dialog);
        }
        if (dialogBoxDisplay == null)
        {
            Debug.LogError("dialogBoxDisplay not found!");
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