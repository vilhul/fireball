using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "AnswerBox", menuName = "Answer")]
public class AnswerBox : ScriptableObject
{
    string desc; // "Choose your weapon!"
    AnswerBox nextAnswer;
    ListenBox nextListen;

    public string GetDesc()
    {
        return desc;
    }

    public AnswerBox GetNextAnswer()
    {
        return nextAnswer;
    }

    public ListenBox GetNextListen()
    {
        return nextListen;
    }
}
