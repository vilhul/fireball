using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListenBoxDisplay : MonoBehaviour
{
    public ListenBox listenBox;

    public ListenBox nextListen;
    public AnswerBox nextAnswer;
    public Sprite sprite;
    public string speech;

    // Start is called before the first frame update
    void Awake()
    {
        // Speech
        speech = listenBox.textContent;

        // Sprite
        sprite = listenBox.sprite;

        listenBox.LogAttribs();

        nextListen = listenBox.nextListen;
        nextAnswer = listenBox.nextAnswer;
    }
}
