using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBoxDisplay : MonoBehaviour
{
    [SerializeField] DialogBox dialogBox;
    [SerializeField] DialogBox nextDialog;

    public void SetNextDialogBox(DialogBox nextDialogBox)
    {
        nextDialog = nextDialogBox;
    }

    public void SetDialogBox(DialogBox dialogBoxIn)
    {
        dialogBox = dialogBoxIn;
    }

    public DialogBox GetDialogBox()
    {
        return dialogBox;
    }

    public Sprite GetSprite()
    {
        return dialogBox.GetSprite() ;
    }

    public DialogBox GetNextDialog()
    {
        return dialogBox.GetNextDialogBox();
    }

    public string GetSpeech()
    {
        return dialogBox.GetTextContent();
    }

    // Start is called before the first frame update
    void Awake()
    {
        nextDialog = dialogBox.GetNextDialogBox();
    }
}
