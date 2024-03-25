using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


// Updates which speech to render (input based), as well as animates the speech (frame based)
public class UpdateSpeech : MonoBehaviour
{
    // This code assumes speeches saved in a dialog are not modefied in any way, ex removed or added
    public DialogBoxDisplay dialogBoxDisplay;
    public int currentSpeechIndex;
    public Text speechText;
    public int timeSinceLastSwitch; // Relative to time passed, increases by one for every deltaTime
    public int animationSpeed; // In frames
    public int shownCharacters;
    public string currentSpeech; // Features won't work when "currentSpeech" in dialogBoxDisplay is used (removed for now), no idea why (dialogBoxDisplay IS a reference)

    public void UpdateCurrentSpeech()
    {
        currentSpeech = dialogBoxDisplay.speechCollection[currentSpeechIndex];
    }

    private void AnimateSpeech()
    {
        if (shownCharacters < currentSpeech.Length) 
        {
            shownCharacters++;
        }
        
        speechText.text = dialogBoxDisplay.speechCollection[currentSpeechIndex].Substring(0, shownCharacters);
    }

    void Start()
    {
        // Getting relevant DialogBoxDisplay object, MUST BE FIRST
        dialogBoxDisplay = GetComponent<DialogBoxDisplay>();

        // Animation
        animationSpeed = 1;
        shownCharacters = 0;
        timeSinceLastSwitch = 0;
        currentSpeechIndex = 0;

        // Getting to the correct child (No cops please)
        Transform textBoxTransform = transform.Find("TextBox");
        if (textBoxTransform != null)
        {
            Transform speechTextTransform = textBoxTransform.Find("SpeechText");
            if (speechTextTransform != null)
            {
                speechText = speechTextTransform.GetComponent<Text>();
                
                // Then updates speech
                UpdateCurrentSpeech();

                if (dialogBoxDisplay == null)
                {
                    Debug.LogError("dialogBoxDisplay not found");
                }
            } 
            else
            {
                Debug.Log("speechTextTransform is empty: " + speechTextTransform );
            }
        }
        else
        {   
            Debug.Log("speechTextTransform is empty: " + textBoxTransform);
        }

        if (dialogBoxDisplay == null) 
        {
            Debug.LogError("dialogBoxDisplay not found!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && currentSpeechIndex < dialogBoxDisplay.speechCollection.Count - 1)
        {
            currentSpeechIndex += 1;
            shownCharacters = 0;
            UpdateCurrentSpeech();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentSpeechIndex > 0)
        {
            currentSpeechIndex -= 1;
            shownCharacters = 0;
            UpdateCurrentSpeech();
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
