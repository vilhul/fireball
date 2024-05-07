using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateUpAndDown : MonoBehaviour
{
    float amp;
    private void Awake()
    {
        amp = Random.Range(0.001f, 0.005f);
    }
    
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(15*Time.time) * amp, 0);    
    }
}
