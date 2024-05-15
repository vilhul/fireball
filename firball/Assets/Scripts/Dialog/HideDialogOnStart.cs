using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideDialogOnStart : MonoBehaviour
{
    public Graphic[] uiComponents; // Array to hold all the UI components

    // Call this method whenever you want to hide the UI element
    public void HideElement()
    {
        // Loop through all UI components
        foreach (Graphic component in uiComponents)
        {
            // Set transparency to 0 to hide the component
            Color color = component.color;
            color.a = 0f;
            component.color = color;
        }
    }

    // Call this method whenever you want to show the UI element again
    public void ShowElement()
    {
        // Loop through all UI components
        foreach (Graphic component in uiComponents)
        {
            // Set transparency to 1 to show the component
            Color color = component.color;
            color.a = 1f;
            component.color = color;
        }
    }

    void Start()
    {
        // Find all UI components under this GameObject and its children
        uiComponents = GetComponentsInChildren<Graphic>();
        HideElement();
    }
}
