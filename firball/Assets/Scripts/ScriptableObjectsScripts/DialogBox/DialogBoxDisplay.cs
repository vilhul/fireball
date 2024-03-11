using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBoxDisplay : MonoBehaviour
{
    public DialogBox dialogBox;

    public List<Text> speechCollection;
    public Image talkerImage;
    public int currentSpeechInContentIndex;
    public Text currentSpeech;

    // Start is called before the first frame update
    void Start()
    {
        dialogBox.LogSpeech();
        // SpeechCollection is currently empty???? check in DialogBox next time
        speechCollection = dialogBox.speechCollection;
        currentSpeechInContentIndex = 0;
        Debug.Log(speechCollection.Count);
        currentSpeech = speechCollection[currentSpeechInContentIndex];

        // Sprite
        talkerImage.sprite = dialogBox.talkerImage;

        dialogBox.LogSpeech();
    }
}
