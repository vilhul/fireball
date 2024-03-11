using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Dialog Box", menuName = "Dialog")]
public class DialogBox : ScriptableObject
{
    // https://www.youtube.com/watch?v=aPXvoWVabPY Bra l�nk f�r scriptable objects
    
    public List<string> speechCollectionInput;
    public List<Text> speechCollection;
    public Sprite talkerImage;

    public void LogSpeech()
    {
        for (int i = 0; i < speechCollectionInput.Count; i++)
        {
            Debug.Log(i);
            //Debug.Log("Current speech: " + speechCollection[i].text);
            //Debug.Log("collection: " + speechCollection);
        }
    }
    public void Start()
    {
        // Helt �rligt; allt under �r ChatGPT som kom p�, men det �r s� j�vla smart s� snor det. KAN inte komma p� en smartare l�sning sj�lv.
        // Kanske bara �r jag som �r noob

        speechCollection = new List<Text>(); // Instantiate the List<Text> before using it

        for (int i = 0; i < speechCollectionInput.Count; i++)
        {
            Text speechText = new GameObject("SpeechText" + i).AddComponent<Text>();
            if (speechCollectionInput[0] != null) // In case someone adds an empty dialog, it wont be added now :) :) :) :)
            {
                speechText.text = speechCollectionInput[i];
                speechCollection.Add(speechText);
            }
        }
    }
}
