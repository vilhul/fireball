using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "AnswerBox", menuName = "Answer")]
public class AnswerBox : ScriptableObject
{
    [SerializeField] string desc; // "Choose your weapon!"
    [SerializeField] DialogBox nextDialog;

    public string GetDesc()
    {
        return desc;
    }

    public DialogBox GetNextListen()
    {
        return nextDialog;
    }
}
