using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpdateListenBox : MonoBehaviour
{
    public ListenBoxDisplay listenBoxDisplay;
    public UpdateListenBoxText listenBoxText;
    public UpdateListenSprite listenSprite;

    public ListenBox listenBox;
    public ListenBox nextListen;

    // Start is called before the first frame update
    void Start()
    {
        listenBoxDisplay = GetComponent<ListenBoxDisplay>();
        listenBoxText = GetComponent<UpdateListenBoxText>();
        listenSprite = GetComponent<UpdateListenSprite>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Dialog updated to next stage");
            listenBoxDisplay.listenBox = listenBoxDisplay.nextListen;
            if (listenBoxDisplay.nextListen != null )
            {
                listenBoxDisplay.nextListen = listenBoxDisplay.listenBox.nextListen;
                listenBoxDisplay.UpdateAttribs();
                listenBoxText.UpdateCurrentSpeech();
                listenSprite.UpdateSprite();
            }
            else if (listenBoxDisplay.nextAnswer != null)
            {
                // Do future code
            }
            else if (listenBoxDisplay.nextAnswer == null && listenBoxDisplay.nextListen == null)
            {
                // End dialog
            }
        }
    }
}
