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
    //public List<Text> speechCollection;
    public Sprite talkerImage;
    public void LogSpeech()
    {
        //for (int i = 0; i < speechCollectionInput.Count; i++)
        //{
        //    Debug.Log("Current speech: " + speechCollection[i].text);
        //}
    }
    public void Awake()
    {
        // Helt ärligt; allt under är ChatGPT som kom på, men det är så jävla smart så snor det. KAN inte komma på en smartare lösning själv.
        // Kanske bara är jag som är noob
        // Nvm det funka inte så har fått skriva om ganska mycket

        //speechCollection = new List<Text>(); // Instantiate the List<Text> before using it
        //for (int i = 0; i < speechCollectionInput.Count; i++)
        //{
        //    if (speechCollectionInput[i] != null)
        //    {
        //        Text speechText = new GameObject("SpeechText" + i).AddComponent<Text>();
        //        speechText.text = speechCollectionInput[i];
        //        speechCollection.Add(speechText);
        //        Debug.Log("Reached: " + i);
        //    }
        //}
    }
}
