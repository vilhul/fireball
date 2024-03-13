using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    private VisualElement animatedFireball;
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        animatedFireball = root.Q<VisualElement>("Fireball");

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void animateFireball()
    {
        animatedFireball.ToggleInClassList("object-up");
        animatedFireball.RegisterCallback<TransitionEndEvent>(animateFireballBack);
    }

    private void animateFireballBack(TransitionEndEvent evt)
    {
        Debug.Log("funktion kallad");
        animatedFireball.ToggleInClassList("object-up");
        animatedFireball.RegisterCallback<TransitionEndEvent>(animateFireball2);
    }

    private void animateFireball2(TransitionEndEvent evt)
    {
        animatedFireball.ToggleInClassList("object-up");
        animatedFireball.RegisterCallback<TransitionEndEvent>(animateFireballBack);
    }
}
