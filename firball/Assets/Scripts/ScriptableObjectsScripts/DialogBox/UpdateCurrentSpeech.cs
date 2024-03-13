using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCurrentSpeech : MonoBehaviour
{
    public DialogBoxDisplay dialogBoxDisplay;

    public int currentSpeechIndex;
    public string currentSpeech;
    public Text speechText;
    // Start is called before the first frame update

    void Start()
    {
        dialogBoxDisplay = GetComponent<DialogBoxDisplay>();
        // Getting to the correct child
        // No cops please
        Transform textBoxTransform = transform.Find("TextBox");
        if (textBoxTransform != null)
        {
            Transform speechTextTransform = textBoxTransform.Find("SpeechText");
            if (speechTextTransform != null)
            {
                speechText = speechTextTransform.GetComponent<Text>();
                speechText.text = "Hello, this is working";
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
            speechText.text = dialogBoxDisplay.speechCollection[dialogBoxDisplay.currentSpeechIndex];
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && dialogBoxDisplay.currentSpeechIndex > 0)
        {
            dialogBoxDisplay.currentSpeechIndex -= 1;
            speechText.text = dialogBoxDisplay.speechCollection[dialogBoxDisplay.currentSpeechIndex];
        }
    }
}