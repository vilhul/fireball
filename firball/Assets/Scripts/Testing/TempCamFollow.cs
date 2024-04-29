using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempCamFollow : MonoBehaviour
{

    private Transform camTransform; 

    // Start is called before the first frame update
    void Start()
    {
        camTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(camTransform);
            camTransform.Translate(2, 0, 0);
        }
    }
}
