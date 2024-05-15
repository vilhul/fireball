using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBoxDisplay : MonoBehaviour
{
    [SerializeField] DialogBox dialogBox;

    public void SetDialogBox(DialogBox dialogBoxIn)
    {
        dialogBox = dialogBoxIn;
    }

    public DialogBox GetDialogBox()
    {
        if (dialogBox != null)
        {
            return dialogBox;
        }
        else
        {
            return null;
        }
    }

    public Sprite GetSprite()
    {
        if (dialogBox != null)
        {
            return dialogBox.GetSprite();
        }
        else
        {
            return null;
        }
    }

    public DialogBox GetNextDialog()
    {
        if (dialogBox != null)
        {
            return dialogBox.GetNextDialogBox();
        }
        else
        {
            return null;
        }   
    }

    public string GetSpeech()
    {
        if (dialogBox != null)
        {
            return dialogBox.GetTextContent();
        }
        else
        {
            return null;
        }
    }
    private void Update()
    {
        Debug.LogWarning(GetNextDialog());
    }
}
