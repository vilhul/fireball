using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListenBoxDisplay : MonoBehaviour
{
    public ListenBox listenBox;

    public ListenBox nextListen;
    public AnswerList nextAnswer;
    public Sprite sprite;
    public string speech;

    public void UpdateAttribs()
    {
        speech = listenBox.textContent;

        // Sprite
        sprite = listenBox.sprite;
    }

    // Start is called before the first frame update
    void Awake()
    {
        // Speech
        speech = listenBox.textContent;

        // Sprite
        sprite = listenBox.sprite;

        //listenBox.LogAttribs();

        nextListen = listenBox.nextListen;
        nextAnswer = listenBox.nextAnswer;
    }
}
