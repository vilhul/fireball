using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDialogUnactiveOnStart : MonoBehaviour
{
    SaveDialogObjectOnStart SaveDialogObjectOnStart;
    // Start is called before the first frame update
    void Start()
    {
        SaveDialogObjectOnStart = GetComponent<SaveDialogObjectOnStart>();
        SaveDialogObjectOnStart.enabled = false;
    }
}
