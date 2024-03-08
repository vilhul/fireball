using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;


[CreateAssetMenu(fileName = "Dialog Box", menuName = "Dialog")]
public class DialogBox : ScriptableObject
{
    // https://www.youtube.com/watch?v=aPXvoWVabPY Bra länk för scriptable objects

    public string speechText;
    public Sprite talkerImage;

    public void PrintInfo()
    {
        Debug.Log("text: " + speechText);
    }
}
