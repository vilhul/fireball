using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Dialog Box", menuName = "Dialog")]
public class DialogBox : ScriptableObject
{
    // https://www.youtube.com/watch?v=aPXvoWVabPY Bra länk för scriptable objects
    
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
        // Helt ärligt; allt under är ChatGPT som kom på, men det är så jävla smart så snor det. KAN inte komma på en smartare lösning själv.
        // Kanske bara är jag som är noob

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
