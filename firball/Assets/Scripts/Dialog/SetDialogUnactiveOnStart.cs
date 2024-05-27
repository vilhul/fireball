using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDialogUnactiveOnStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindWithTag("Dialog").SetActive(false);
    }
}
