using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "DialogBox", menuName = "Dialog")]
public class DialogBox : ScriptableObject
{
    [SerializeField] string textContent;
    [SerializeField] Sprite sprite;
    [SerializeField] DialogBox nextDialog;
    [SerializeField] AnswerList currentAnswers;

    public string GetTextContent()
    {
        return textContent;
    }

    public Sprite GetSprite()
    {
        return sprite;
    }

    public DialogBox GetNextDialogBox()
    {
        return nextDialog;
    }

    public AnswerList GetCurrentAnswers()
    {
        return currentAnswers;
    }

    public void LogAttribs()
    {
        Debug.Log("Text: " + textContent);
        Debug.Log("Sprite: " + sprite);
    }
}

