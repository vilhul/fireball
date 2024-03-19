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
    private VisualElement meteor;

    private void OnEnable()
    {
        //definierar rootVisualElement, är som document i html
        rootEl = uiDoc.rootVisualElement;

        //definerar de tre knapparna och säger att när de klickas kör denna funktion
        startBtn = rootEl.Query<Button>("start");
        optionsBtn = rootEl.Query<Button>("options");
        quitBtn = rootEl.Query<Button>("quit");

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

        //skapar flera fireballs
        for (int i = 0; i < 5; i++) {
        Debug.Log("skapade meteor");
        meteor = new VisualElement();
        rootEl.Add(meteor);
        meteor.AddToClassList("meteor");
        System.Random random = new System.Random();
        int randomNum = random.Next(200, 701);
        meteor.style.height = randomNum;
        meteor.style.width = randomNum;
        meteor.style.top = -randomNum;
        meteor.style.right = -randomNum;
        meteor.ToggleInClassList("animate-meteor");
        }

        var meteors = rootEl.Query(className: "meteor").ToList();

        foreach (var meteor in meteors)
        {
            System.Random random = new System.Random();
            int randomNum = random.Next(1, 400);
            Debug.Log("nåt");
            rootEl.schedule.Execute(() =>
            {
                
                meteor.ToggleInClassList("animate-meteor");
                Debug.Log("animeras");
            }).Every(4000 + randomNum * 4);

        }


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
