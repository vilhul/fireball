using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnswerListDisplay : MonoBehaviour
{
    [SerializeField] DialogBoxDisplay dialogBoxDisplay;
    [SerializeField] UpdateAnswerListAnswers updateAnswerListAnswers;

    [SerializeField] Transform _3AO1;
    [SerializeField] Transform _3AO2;
    [SerializeField] Transform _3AO3;

    [SerializeField] Transform _2AO1;
    [SerializeField] Transform _2AO2;

    [SerializeField] Transform _1AO1;

    [SerializeField] Transform _3A;
    [SerializeField] Transform _2A;
    [SerializeField] Transform _1A;

    public void UpdateShownAnswerOptions()
    {
        if (dialogBoxDisplay.GetDialogBox().GetCurrentAnswers() != null)
        {
            // if 1 answers
            if (dialogBoxDisplay.GetDialogBox().GetCurrentAnswers().GetAnswers().Length == 1)
            {
                _1A.gameObject.SetActive(true);
                _2A.gameObject.SetActive(false);
                _3A.gameObject.SetActive(false);
            }
            // if 2 answers
            if (dialogBoxDisplay.GetDialogBox().GetCurrentAnswers().GetAnswers().Length == 2)
            {
                _1A.gameObject.SetActive(false);
                _2A.gameObject.SetActive(true);
                _3A.gameObject.SetActive(false);
            }
            // if 3 answers
            if (dialogBoxDisplay.GetDialogBox().GetCurrentAnswers().GetAnswers().Length == 3)
            {
                _1A.gameObject.SetActive(false);
                _2A.gameObject.SetActive(false);
                _3A.gameObject.SetActive(true);
            }
            if (dialogBoxDisplay.GetDialogBox().GetCurrentAnswers().GetAnswers().Length > 3)
            {
                Debug.LogError("Too many answerOptions");
            }
        }
    }

    public List<Transform> GetCurrentAnswerTransforms()
    {
        List<Transform> transforms = new List<Transform>();
        if (dialogBoxDisplay.GetDialogBox().GetCurrentAnswers() != null)
        {
            if (dialogBoxDisplay.GetDialogBox().GetCurrentAnswers().GetAnswers().Length == 3)
            {
                transforms.Add(_3AO1);
                transforms.Add(_3AO2);
                transforms.Add(_3AO3);
            }
            if (dialogBoxDisplay.GetDialogBox().GetCurrentAnswers().GetAnswers().Length == 2)
            {
                transforms.Add(_2AO1);
                transforms.Add(_2AO2);
            }
            if (dialogBoxDisplay.GetDialogBox().GetCurrentAnswers().GetAnswers().Length == 1)
            {
                transforms.Add(_1AO1);
            }
        }
        return transforms;
    }

    // Start is called before the first frame update
    void Awake()
    {
        updateAnswerListAnswers = GetComponent<UpdateAnswerListAnswers>();
        dialogBoxDisplay = GetComponent<DialogBoxDisplay>();
        Transform answerTransform = transform.Find("Answer");
        if (answerTransform != null)
        {
            Transform answerContainer = answerTransform.Find("AnswerContainer");
            if (answerContainer != null)
            {
                _3A = answerContainer.Find("3A");
                if (_3A != null)
                {
                    _3AO1 = _3A.Find("3AO1");
                    _3AO2 = _3A.Find("3AO2");
                    _3AO3 = _3A.Find("3AO3");
                }

                _2A = answerContainer.Find("2A");
                if (_2A != null)
                {
                    _2AO1 = _2A.Find("2AO1");
                    _2AO2 = _2A.Find("2AO2");
                }

                _1A = answerContainer.Find("1A");
                if (_1A != null)
                {
                    _1AO1 = _1A.Find("1AO1");
                }
            }
            else
            {
                Debug.LogWarning("answerContainer == null");
            }
        }
        else
        {
            Debug.LogWarning("answerTransform == null");
        }
        UpdateShownAnswerOptions();
        updateAnswerListAnswers.UpdateAnswerTexts();
    }
}
