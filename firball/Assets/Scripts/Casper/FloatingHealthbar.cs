using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthbar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Transform target;
    private Vector3 offset = new Vector3(0, 1, 0);

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
// n�sta grej att g�ra �r att fixa detta p� player och g�ra s� att player kan interagera med goomba o mole