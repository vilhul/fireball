using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpdateListenBox : MonoBehaviour
{
    public ListenBoxDisplay listenBoxDisplay;

    public ListenBox listenBox;
    public ListenBox nextListen;

    // Start is called before the first frame update
    void Start()
    {
        listenBoxDisplay = GetComponent<ListenBoxDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            listenBoxDisplay.listenBox = listenBoxDisplay.nextListen;
            if (listenBoxDisplay.nextListen != null )
            {
                listenBoxDisplay.nextListen = listenBoxDisplay.listenBox.nextListen;
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
