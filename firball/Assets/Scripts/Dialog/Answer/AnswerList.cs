using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnswerList", menuName = "AnswerList")]
public class AnswerList : ScriptableObject
{
    AnswerBox[] answers;
    public AnswerBox[] GetAnswers()
    {
        return answers;
    }
}
