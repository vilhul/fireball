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

    public void LoadDialog(DialogBox startDialog)
    {
        SetDialogActive();
        dialog.GetComponent<DialogBoxDisplay>().SetDialogBox(startDialog);
    }

    void SetDialogActive()
    {
        dialog.SetActive(true);
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && Input.GetKeyDown(KeyCode.O)) 
        {
            LoadDialog(dialogToLoad);
            Debug.Log("New Dialog Loaded");
        }
    }
}
