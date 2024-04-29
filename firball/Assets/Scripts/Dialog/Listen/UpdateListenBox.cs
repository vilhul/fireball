using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpdateListenBox : MonoBehaviour
{
    [SerializeField] ListenBoxDisplay listenBoxDisplay;
    [SerializeField] UpdateListenBoxText listenBoxText;
    [SerializeField] UpdateListenSprite listenSprite;

    [SerializeField] ListenBox listenBox;
    [SerializeField] ListenBox nextListen;

    public ListenBox GetListenBox()
    {
        return listenBox;
    }
    public ListenBox GetNextListenBox()
    {
        return nextListen;
    }

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
            listenBoxDisplay.SetListenBox(listenBoxDisplay.GetNextListen());
            if (listenBoxDisplay.GetListenBox() != null )
            {
                listenBoxDisplay.SetNextListenBox(listenBoxDisplay.GetNextListen());
                listenBoxDisplay.UpdateAttribs();
                listenBoxText.UpdateCurrentSpeech();
                listenSprite.UpdateSprite();
            }
            else if (listenBoxDisplay.GetNextAnswer() != null)
            {
                //
            }
            else if (listenBoxDisplay.GetNextAnswer() == null && listenBoxDisplay.GetNextListen() == null)
            {
                gameObject.SetActive(false);
                Destroy(gameObject); // End dialog, for now
            }
        }
    }
}
