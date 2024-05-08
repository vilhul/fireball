using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateUpAndDown : MonoBehaviour
{
    float amp;
    float speed;
    private void Awake()
    {
        amp = Random.Range(0.001f, 0.003f);
        speed = Random.Range(8f, 15f);
    }
    
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(speed*Time.time) * amp, 0);    
    }
}
