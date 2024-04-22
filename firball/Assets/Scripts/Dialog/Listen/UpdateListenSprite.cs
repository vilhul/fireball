using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpdateListenSprite : MonoBehaviour
{
    public Image spriteContainer;
    public ListenBoxDisplay listenBoxDisplay;

    public void UpdateSprite()
    {
        listenBoxDisplay = GetComponent<ListenBoxDisplay>();
        spriteContainer.sprite = listenBoxDisplay.sprite;
    }

    // Start is called before the first frame update
    void Awake()
    {
        listenBoxDisplay = GetComponent<ListenBoxDisplay>();
        // Getting to correct child
        // Vet genuint inte varför jag inte bara la skriptet PÅ spriten direkt, men pallar inte göra om
        Transform listen = transform.Find("Listen");
        if (listen != null)
        {
            Transform imageBoxTransform = listen.Find("ImageBox");
            if (imageBoxTransform != null)
            {
                Transform talkerImageTransform = imageBoxTransform.Find("TalkerImage");
                if (talkerImageTransform != null)
                {
                    spriteContainer = talkerImageTransform.GetComponent<Image>();
                }
                else
                {
                    Debug.Log("talkerImageTransform is empty: " + talkerImageTransform);
                }
            }
            else
            {
                Debug.Log("imageBoxTransform is empty: " + imageBoxTransform);
            }
        }
            

        if (listenBoxDisplay == null)
        {
            Debug.LogError("listenBoxDisplay not found!");
        }
        if (listenBoxDisplay.sprite != null && spriteContainer != null)
        {
            spriteContainer.sprite = listenBoxDisplay.sprite;
        } 
        else if (listenBoxDisplay.sprite == null)
        {
            Debug.LogError("listenSprite == null");
        }
        else if (spriteContainer == null)
        {
            Debug.LogError("spriteContainer == null");
        }
    }
}
