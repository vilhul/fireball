using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDialogBox : MonoBehaviour
{
    public GameObject DialogBoxPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(DialogBoxPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
