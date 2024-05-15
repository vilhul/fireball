using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogLoader : MonoBehaviour
{
    // if finding it through scripts prove hard:
    //[SerializeField] GameObject Dialog;
    [SerializeField] DialogBox dialogToLoad;
    GameObject dialog;
    // Start is called before the first frame update

    public void LoadDialog()
    {
        SetDialogActive();
        dialog.GetComponent<DialogBoxDisplay>().SetDialogBox(dialogToLoad);
        dialog.GetComponent<UpdateDialogBox>().UpdateAll();
    }

    void SetDialogActive()
    {
        dialog.SetActive(true);
    }

    public DialogBox GetDialogToLoad()
    {
        if (dialogToLoad != null)
        {
            return dialogToLoad;
        }
        else { return null; }
    }
    void DialogGameObjectStartLogic()
    {
        // Used to find and set Dialog
        dialog = GameObject.FindWithTag("Dialog");
    }

    void Start()
    {
        DialogGameObjectStartLogic();
        // dialog.GetComponent<DialogBoxDisplay>();
    }
}
