using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthbar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    public void UpdateHealthbar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
        transform.position = target.position + offset;
    }
}

// https://www.youtube.com/watch?v=_lREXfAMUcE 
// nästa grej att göra är att fixa detta på player och göra så att player kan interagera med goomba o mole