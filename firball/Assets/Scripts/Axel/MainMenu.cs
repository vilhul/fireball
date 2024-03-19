using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private UIDocument uiDoc;
    private VisualElement rootEl;
    private Button startBtn;
    private Button optionsBtn;
    private Button quitBtn;
    private VisualElement animatedFireball;

    private void OnEnable()
    {
        rootEl = uiDoc.rootVisualElement;

        startBtn = rootEl.Query<Button>("start");
        optionsBtn = rootEl.Query<Button>("options");
        quitBtn = rootEl.Query<Button>("quit");
        animatedFireball = rootEl.Query<VisualElement>("fireball");

        setupAnimation();

        rootEl.schedule.Execute(() => animatedFireball.ToggleInClassList("object-up")).StartingIn(100);

        startBtn.RegisterCallback<ClickEvent>( (evt) =>
        {
            startBtnClickedMethod();
        });

        optionsBtn.RegisterCallback<ClickEvent>((evt) =>
        {
            optionsBtnClickedMethod();
        });

        quitBtn.RegisterCallback<ClickEvent>((evt) =>
        {
            quitBtnClickedMethod();
        });
    }

    private void setupAnimation()
    {
        animatedFireball.RegisterCallback<TransitionEndEvent>((evt) =>
        {
            Debug.Log("Slut på animation");
            animatedFireball.ToggleInClassList("object-up");
        });
    }

    private void startBtnClickedMethod()
    {
        Debug.Log("startknapp klickad");
    }

    private void optionsBtnClickedMethod()
    {
        Debug.Log("inställningsknapp klickad");
    }

    private void quitBtnClickedMethod()
    {
        Debug.Log("lämnaknapp klickad");
    }
}
