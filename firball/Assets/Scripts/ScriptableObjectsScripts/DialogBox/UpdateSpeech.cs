using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Updates which speech to render (input based), as well as animates the speech (frame based)
public class UpdateSpeech : MonoBehaviour
{
    public DialogBoxDisplay dialogBoxDisplay;

    public int currentSpeechIndex;
    public string currentSpeech;
    public Text speechText;
    public int framesSinceLastSwitch;
    public int animationSpeed; // In frames
    public int shownCharacters;

    // Start is called before the first frame update

    public void AnimateSpeech()
    {
        speechText.text = dialogBoxDisplay.speechCollection[dialogBoxDisplay.currentSpeechIndex].Substring(0, shownCharacters);
    }

    void Start()
    {
        // Getting relevant DialogBoxDisplay object
        dialogBoxDisplay = GetComponent<DialogBoxDisplay>();

        // Animation
        animationSpeed = 10;
        shownCharacters = 0;
        framesSinceLastSwitch = 0;

        // Getting to the correct child (No cops please)
        Transform textBoxTransform = transform.Find("TextBox");
        if (textBoxTransform != null)
        {
            Transform speechTextTransform = textBoxTransform.Find("SpeechText");
            if (speechTextTransform != null)
            {
                speechText = speechTextTransform.GetComponent<Text>();
                speechText.text = dialogBoxDisplay.currentSpeech.Substring(0, shownCharacters);
            }
        }

        if (dialogBoxDisplay == null) 
        {
            Debug.LogError("dialogBoxDisplay not found!");
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && dialogBoxDisplay.currentSpeechIndex < dialogBoxDisplay.speechCollection.Count - 1) 
        {
            dialogBoxDisplay.currentSpeechIndex += 1;
            shownCharacters = 0;
            framesSinceLastSwitch = 0;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && dialogBoxDisplay.currentSpeechIndex > 0)
        {
            dialogBoxDisplay.currentSpeechIndex -= 1;
            shownCharacters = 0;
            framesSinceLastSwitch = 0;
        }
        if (framesSinceLastSwitch > animationSpeed)
        {
            AnimateSpeech();
            framesSinceLastSwitch = 0;
        }
        
        // Run last
        framesSinceLastSwitch++;
    }
}