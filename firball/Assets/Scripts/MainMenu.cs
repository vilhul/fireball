using System;
using System.Collections;
using System.Collections.Generic;
// using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private SceneAsset persistentScene;
    [SerializeField] private SceneAsset startingRoom;



    [SerializeField] private UIDocument uiDoc;
    private VisualElement rootEl;
    private Button startBtn;
    private Button optionsBtn;
    private Button quitBtn;
    private Button switchCharacter;
    private VisualElement meteor;
    public CharacterChangerManager characterChangerManager;
    //Hej Azel :DD
    SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        //definierar rootVisualElement, �r som document i html
        rootEl = uiDoc.rootVisualElement;

        //definerar de FYRA knapparna och s�ger att n�r de klickas k�r denna funktion
        startBtn = rootEl.Query<Button>("start");
        optionsBtn = rootEl.Query<Button>("options");
        quitBtn = rootEl.Query<Button>("quit");
        switchCharacter = rootEl.Query<Button>("SwitchCharacterButton");

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

        switchCharacter.RegisterCallback<ClickEvent>((evt) =>
        {
            characterChangerManager.ActivatePlayerSpriteChange();

        });

        

        //skapar flera fireballs med random storlek och random position vart de spawnar horisontellt
        for (int i = 0; i < 5; i++) {
        Debug.Log("skapade meteor");
        meteor = new VisualElement();
        rootEl.Add(meteor);
        meteor.AddToClassList("meteor");
        System.Random random = new System.Random();
        int randomNum = random.Next(200, 401);
        meteor.style.height = randomNum;
        meteor.style.width = randomNum;
        meteor.style.top = -randomNum;
        int randomPos = random.Next(randomNum, 1920-randomNum);
        meteor.style.right = -randomPos;
        meteor.ToggleInClassList("animate-meteor");
        }

        // skapar lista av de och loopar genom den s� att de animeras
        var meteors = rootEl.Query(className: "meteor").ToList();
        foreach (var meteor in meteors)
        {
            //random n�r de ska swisha f�rbi p� sk�rmen
            System.Random random = new System.Random();
            int randomNum = random.Next(1, 400);
            Debug.Log("n�t");
            rootEl.schedule.Execute(() =>
            {
                
                meteor.ToggleInClassList("animate-meteor");
                
            }).Every(4000 + randomNum * 4);

            //�ndrar sprite varje 0.5 sekunder
            rootEl.schedule.Execute(() =>
            {
                meteor.ToggleInClassList("switch-fireball-image");
               
            }).Every(20);

        }


    }

    private void startBtnClickedMethod()
    {
        Debug.Log("startknapp klickad");
        SceneManager.LoadScene(persistentScene.name, LoadSceneMode.Single);
        SceneManager.LoadSceneAsync(startingRoom.name, LoadSceneMode.Additive);
    }

    private void optionsBtnClickedMethod()
    {
        Debug.Log("inst�llningsknapp klickad");
    }

    private void quitBtnClickedMethod()
    {
        Debug.Log("l�mnaknapp klickad");
        Application.Quit();
        //koden nedan �r bara f�r att quitknappen ska fungera i editorn
        UnityEditor.EditorApplication.isPlaying = false;
    }

    /*private void switchCharacterClickedMethod() {
        Debug.Log("Clickad");
        spriteRenderer.sprite = partygnome;
    }*/
}
