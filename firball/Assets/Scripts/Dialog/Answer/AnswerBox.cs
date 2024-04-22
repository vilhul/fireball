using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "AnswerBox", menuName = "Answer")]
public class AnswerBox : ScriptableObject
{
    public string desc; // "Choose your weapon!"
    public AnswerBox nextAnswer;
    public ListenBox nextListen;
}
