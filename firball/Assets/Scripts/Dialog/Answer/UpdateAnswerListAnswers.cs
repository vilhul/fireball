using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateAnswerListAnswers : MonoBehaviour
{
    [SerializeField] AnswerListDisplay answerListDisplay;
    [SerializeField] List<Transform> answerTransformList;
    [SerializeField] List<GameObject> answerGameObjectList;

    void UpdateCurrentGameObjects()
    {
        answerTransformList = answerListDisplay.GetCurrentAnswersTransforms();
        answerGameObjectList.Clear();
        foreach (Transform t in answerTransformList)
        {
            answerGameObjectList.Add(t.gameObject);
        }
    }

    void UpdateAnswerBoxText()
    {
        foreach (AnswerBox answer in answerListDisplay.GetAnswerList().GetAnswers())
        {
            Debug.Log(answer.GetDesc());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        answerListDisplay = GetComponent<AnswerListDisplay>();
        answerTransformList = answerListDisplay.GetCurrentAnswersTransforms();
        foreach (Transform t in answerTransformList)
        {
            answerGameObjectList.Add(t.gameObject);
        }
        UpdateAnswerBoxText();
    }
}
