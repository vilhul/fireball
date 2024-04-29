using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListenBoxDisplay : MonoBehaviour
{
    [SerializeField] ListenBox listenBox;

    [SerializeField] ListenBox nextListen;
    [SerializeField] AnswerList nextAnswerList;
    [SerializeField] Sprite sprite;
    [SerializeField] string speech;

    public void SetNextListenBox(ListenBox nextListenBox)
    {
        nextListen = nextListenBox;
    }

    public void SetListenBox(ListenBox listenBoxIn)
    {
        listenBox = listenBoxIn;
    }

    public ListenBox GetListenBox()
    {
        return listenBox;
    }

    public Sprite GetSprite()
    {
        return sprite;
    }

    public ListenBox GetNextListen()
    {
        return nextListen;
    }

    public AnswerList GetNextAnswer()
    {
        return nextAnswerList;
    }

    public string GetSpeech()
    {
        return speech;
    }

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
        nextAnswerList = listenBox.nextAnswer;

        while (sprite == null)
        {
            sprite = listenBox.sprite;
        }
    }
}
