using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpdateDialogBox : MonoBehaviour
{
    [SerializeField] DialogBoxDisplay dialogBoxDisplay;
    [SerializeField] UpdateDialogBoxText dialogBoxText;
    [SerializeField] UpdateDialogSprite dialogSprite;

    [SerializeField] DialogBox dialogBox;
    [SerializeField] DialogBox nextDialog;

    public DialogBox GetDialogBox()
    {
        return dialogBox;
    }
    public DialogBox GetNextDialogBox()
    {
        return nextDialog;
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogBoxDisplay = GetComponent<DialogBoxDisplay>();
        dialogBoxText = GetComponent<UpdateDialogBoxText>();
        dialogSprite = GetComponent<UpdateDialogSprite>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Dialog updated to next stage");
            if (dialogBoxDisplay.GetNextDialog() != null)
            {
                dialogBoxDisplay.SetDialogBox(dialogBoxDisplay.GetNextDialog());
                dialogBoxDisplay.SetNextDialogBox(dialogBoxDisplay.GetNextDialog());
                dialogBoxText.UpdateCurrentSpeech();
                dialogSprite.UpdateSprite();
            }
            else if (dialogBoxDisplay.GetDialogBox().GetCurrentAnswers() == null && dialogBoxDisplay.GetNextDialog() == null)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
