using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBoxDisplay : MonoBehaviour
{
    public DialogBox dialogBox;

    public Text speechText;
    public Image talkerImage;

    // Start is called before the first frame update
    void Start()
    {
        dialogBox.PrintInfo();
        talkerImage.sprite = dialogBox.talkerImage;
        speechText.text = dialogBox.speechText;
        
    }
}
