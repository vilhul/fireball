using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogBoxDisplay : MonoBehaviour
{
    public DialogBox dialogBox;

    public List<string> speechCollection;
    public Image talkerImage;
    public int currentSpeechIndex;
    public string currentSpeech;


    // Start is called before the first frame update
    void Start()
    {
        // Speech
        dialogBox.Awake();
        dialogBox.LogSpeech();
        speechCollection = dialogBox.speechCollectionInput;
        currentSpeechIndex = 0;
        currentSpeech = speechCollection[currentSpeechIndex];

        // Sprite
        talkerImage.sprite = dialogBox.talkerImage;
    }
}
