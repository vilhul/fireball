using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRender : MonoBehaviour
{
    // Hatar semikolon, den ger error i alla fall

    private SpriteRenderer sRenderer;
    private void SetInvis(bool invisState)
    {
        sRenderer.enabled = invisState;
    }
    // Start is called before the first frame update
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();

        if (sRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on parent object");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!sRenderer.enabled)
            {
                SetInvis(true);
            }
            else
            {
                SetInvis(false);
            }
        }
    }
}
