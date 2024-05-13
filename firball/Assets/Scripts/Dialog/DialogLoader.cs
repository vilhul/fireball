using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogLoader : MonoBehaviour
{
    // if finding it through scripts prove hard:
    //[SerializeField] GameObject Dialog;
    GameObject Dialog;
    // Start is called before the first frame update

    void DialogGameObjectStartLogic()
    {
        // Used to find and set Dialog
        Dialog = GameObject.FindWithTag("Dialog");
    }

    void Start()
    {
        DialogGameObjectStartLogic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
