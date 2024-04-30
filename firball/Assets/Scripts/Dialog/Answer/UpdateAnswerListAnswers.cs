using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateAnswerListAnswers : MonoBehaviour
{
    [SerializeField] AnswerListDisplay answerListDisplay;
    [SerializeField] DialogBoxDisplay dialogBoxDisplay;

    public void UpdateAnswerTexts()
    {
        if (answerListDisplay != null)
        {
            int i = 0;
            foreach (Transform t in answerListDisplay.GetCurrentAnswerTransforms())
            {
                Text textElement = t.GetChild(0).GetComponent<Text>();
                textElement.text = dialogBoxDisplay.GetDialogBox().GetCurrentAnswers().GetAnswers()[i].GetDesc();
                i++;
            } 
        }
    }
    void Start()
    {
        dialogBoxDisplay = GetComponent<DialogBoxDisplay>();
        answerListDisplay = GetComponent<AnswerListDisplay>();
    }
}
