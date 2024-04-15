using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "ListenBox", menuName = "Listen")]
public class ListenBox : ScriptableObject
{
    public string textContent;
    public Sprite sprite;
    public ListenBox nextListen;
    public AnswerBox nextAnswer;

    public void LogAttribs()
    {
        Debug.Log("Text: " + textContent);
        Debug.Log("Sprite: " + sprite);
    }
}

