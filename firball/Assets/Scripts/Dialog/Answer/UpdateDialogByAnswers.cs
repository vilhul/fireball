using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        List<Transform> currentAnswers = answerListDisplay.GetCurrentAnswerTransforms();
        if (currentAnswers != null)
        {
            foreach (Transform t in currentAnswers)
            {
                if (t.gameObject.GetComponent<SelectableAnswers>().GetClicked() && !Input.GetKeyDown(KeyCode.Space))
                {
                    DialogBox nextDia = dialogBoxDisplay.GetDialogBox().GetCurrentAnswers().GetAnswers()[i].GetNextListen();
                    SetDialogBox(nextDia);
                    currentAnswers[i].gameObject.GetComponent<SelectableAnswers>().SetClickedFalse();
                    break;
                }
                i++;
            }
            currentAnswers.Clear();
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
