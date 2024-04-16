using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "DialogBox", menuName = "Dialog")]
public class DialogBox : ScriptableObject
{
    // https://www.youtube.com/watch?v=aPXvoWVabPY Bra länk för scriptable objects
    
    public List<string> speechCollectionInput;
    public Sprite talkerImage;
    public void LogSpeech()
    {
        for (int i = 0;  i < speechCollectionInput.Count; ++i)
        {
            Debug.Log("Speech" + i + ": " + speechCollectionInput[i]);
        }
    }
}
