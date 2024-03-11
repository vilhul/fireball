using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCurrentSpeech : MonoBehaviour
{
    public DialogBoxDisplay dialogBoxDisplay;

    public int currentSpeechInContentIndex;
    public Text currentSpeechInContent;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(dialogBoxDisplay.currentSpeech.text);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            dialogBoxDisplay.currentSpeech = dialogBoxDisplay.speechCollection[currentSpeechInContentIndex];
        }
    }
}