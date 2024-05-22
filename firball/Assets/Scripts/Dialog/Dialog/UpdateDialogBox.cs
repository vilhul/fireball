using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpdateDialogBox : MonoBehaviour
{
    [SerializeField] DialogBoxDisplay dialogBoxDisplay;
    [SerializeField] UpdateDialogBoxText dialogBoxText;
    [SerializeField] UpdateDialogSprite dialogSprite;
    AnswerListDisplay answerListDisplay;
    UpdateAnswerListAnswers updateAnswerListAnswers;

    // called from other scripts when they update dialogBox
    public void UpdateAll()
    {
        if (dialogBoxDisplay.GetDialogBox() != null)
        {
            if (dialogBoxDisplay.GetDialogBox().GetCurrentAnswers() == null
            && dialogBoxDisplay.GetNextDialog() == null)
            {
                gameObject.SetActive(false);
                return;
            }
            else if (dialogBoxDisplay.GetDialogBox().GetCurrentAnswers() == null)
            {
                answerListDisplay.UpdateShownAnswerOptions();
            }
            dialogBoxText.UpdateCurrentSpeech();
            dialogSprite.UpdateSprite();
            answerListDisplay.UpdateShownAnswerOptions();
            updateAnswerListAnswers.UpdateAnswerTexts();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogBoxDisplay = GetComponent<DialogBoxDisplay>();
        dialogBoxText = GetComponent<UpdateDialogBoxText>();
        dialogSprite = GetComponent<UpdateDialogSprite>();
        answerListDisplay = GetComponent<AnswerListDisplay>();
        updateAnswerListAnswers = GetComponent<UpdateAnswerListAnswers>();
    }

    // Update is called once per frame
    void Update()
    { 
        // Detect "next
        if (Input.GetKeyDown(KeyCode.F) && dialogBoxDisplay.GetNextDialog() != null)
        {
            if (dialogBoxDisplay.GetNextDialog() != null)
            {
                // Sets to correct box, changes to wrong one elsewhere??!?
                // Problem likely lies in UpdateByAnswer
                dialogBoxDisplay.SetDialogBox(dialogBoxDisplay.GetNextDialog());
                UpdateAll();
            }
        }
        if (dialogBoxDisplay.GetDialogBox() == null && dialogBoxDisplay.GetNextDialog() == null)
        {
            gameObject.SetActive(false);
        }
    }
}