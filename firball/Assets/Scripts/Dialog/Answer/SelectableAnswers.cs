using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class SelectableAnswers : MonoBehaviour
{
    [SerializeField] private Button button;

    bool clicked;
    public void SetClickedTrue()
    {
        clicked = true;
    }

    public void SetClickedFalse()
    {
        clicked = false;
    }

    public bool GetClicked()
    {
        return clicked;
    }

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetClickedTrue);
        SetClickedFalse();
    }
    void LateUpdate()
    {
        SetClickedFalse();
    }
}