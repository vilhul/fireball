using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class UpdateDialogByAnswers : MonoBehaviour
{
    AnswerListDisplay answerListDisplay;
    DialogBoxDisplay dialogBoxDisplay;
    UpdateDialogBox updateDialogBox;

    void SetDialogBox(DialogBox diaBox)
    {
        dialogBoxDisplay.SetDialogBox(diaBox);
        updateDialogBox.UpdateAll();
    }

    void CheckForClicks()
    {
        int i = 0;
        foreach (Transform t in answerListDisplay.GetCurrentAnswerTransforms())
        {
            if (t.gameObject.GetComponent<SelectableAnswers>().GetClicked())
            {
                DialogBox nextDia = dialogBoxDisplay.GetDialogBox().GetCurrentAnswers().GetAnswers()[i].GetNextListen();
                SetDialogBox(nextDia);
                break;
            }
            i++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogBoxDisplay = GetComponent<DialogBoxDisplay>();
        updateDialogBox = GetComponent<UpdateDialogBox>();
        answerListDisplay = GetComponent<AnswerListDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForClicks();
    }
}
