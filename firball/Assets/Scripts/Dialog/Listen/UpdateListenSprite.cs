using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpdateListenSprite : MonoBehaviour
{
    [SerializeField] Image spriteContainer;
    [SerializeField] ListenBoxDisplay listenBoxDisplay;

    public Image GetImage()
    {
        return spriteContainer;
    }

    public ListenBoxDisplay GetListenBoxDisplay()
    {
        return listenBoxDisplay;
    }

    public void UpdateSprite()
    {
        listenBoxDisplay = GetComponent<ListenBoxDisplay>();
        spriteContainer.sprite = listenBoxDisplay.GetSprite();
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
        if (listenBoxDisplay.GetSprite() != null && spriteContainer != null)
        {
            spriteContainer.sprite = listenBoxDisplay.GetSprite();
        } 
        else if (listenBoxDisplay.GetSprite() == null)
        {
            Debug.LogError("listenSprite == null");
        }
        else if (spriteContainer == null)
        {
            Debug.LogError("spriteContainer == null");
        }
    }
}
