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
            && dialogBoxDisplay.GetNextDialog() == null
            && dialogBoxDisplay.GetDialogBox().GetTextContent() == "")
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
        else
        {
            gameObject.SetActive(false);
            return;
        }
        Debug.Log("DialogBox: " + dialogBoxDisplay.GetDialogBox().ToString());
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
        //Debug.Log(dialogBoxDisplay.GetDialogBox());
        //Debug.Log(dialogBoxDisplay.GetNextDialog());
        // Detect "next"
        if (Input.GetKeyDown(KeyCode.F) && dialogBoxDisplay.GetDialogBox().GetCurrentAnswers() == null)
        {
            dialogBoxDisplay.SetDialogBox(dialogBoxDisplay.GetNextDialog());
            UpdateAll();   
        }
    }
}