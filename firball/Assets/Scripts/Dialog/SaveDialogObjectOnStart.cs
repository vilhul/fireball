using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDialogObjectOnStart : MonoBehaviour
{
    GameObject dialog;

    public GameObject GetDialogObject()
    {
        if (dialog != null)
        {
            return dialog;
        }
        else { return null; }
    }

    // Start is called before the first frame update
    void Start()
    {
        dialog = GameObject.FindWithTag("Dialog");
    }
}
