using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        dialogBox.Awake();
        dialogBox.LogSpeech();
        speechCollection = dialogBox.speechCollection;
        currentSpeechInContentIndex = 0;
        currentSpeech = speechCollection[currentSpeechInContentIndex];

        // Sprite
        talkerImage.sprite = dialogBox.talkerImage;
    }
}
