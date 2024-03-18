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
    public string currentSpeech;

    // Start is called before the first frame update
    void Start()
    {
        // Speech
        speechCollection = dialogBox.speechCollectionInput;

        // Sprite
        talkerImage.sprite = dialogBox.talkerImage;
    }
}

