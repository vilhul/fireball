using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Updates which speech to render (input based), as well as animates the speech (frame based)
public class UpdateSpeech : MonoBehaviour
{
    // This code assumes speeches saved in a dialog are not modefied in any way, ex removed or added
    private DialogBoxDisplay dialogBoxDisplay;

    private int currentSpeechIndex;
    private Text speechText;
    private int timeSinceLastSwitch; // Relative to time passed, increases by one for every deltaTime
    private int animationSpeed; // In frames
    private int shownCharacters;
    private string currentSpeech; // Features won't work when "currentSpeech" in dialogBoxDisplay is used (removed for now), no idea why (dialogBoxDisplay IS a reference)

    private void UpdateCurrentSpeech()
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

        currentSpeech = dialogBoxDisplay.currentSpeech;

        // Animation
        animationSpeed = 5;
        shownCharacters = 0;
        timeSinceLastSwitch = 0;

        // Getting to the correct child (No cops please)
        Transform textBoxTransform = transform.Find("TextBox");
        if (textBoxTransform != null)
        {
            Transform speechTextTransform = textBoxTransform.Find("SpeechText");
            if (speechTextTransform != null)
            {
                speechText = speechTextTransform.GetComponent<Text>();
                speechText.text = currentSpeech.Substring(0, shownCharacters);
            }
        }

        if (dialogBoxDisplay == null) 
        {
            Debug.LogError("dialogBoxDisplay not found!");
        }
        UpdateCurrentSpeech();
    }


    private void Update()
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
    private void FixedUpdate()
    {
        if (timeSinceLastSwitch > animationSpeed) // Time so laggy players don't get stuck in dialog or get slower dialog
        {
            AnimateSpeech();
        }
        timeSinceLastSwitch++;
    }
}
