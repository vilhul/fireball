using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpdateDialogSprite : MonoBehaviour
{
    [SerializeField] Image spriteContainer;
    [SerializeField] DialogBoxDisplay dialogBoxDisplay;

    public Image GetImage()
    {
        return spriteContainer;
    }

    public DialogBoxDisplay GetDialogBoxDisplay()
    {
        return dialogBoxDisplay;
    }

    public void UpdateSprite()
    {
        dialogBoxDisplay = GetComponent<DialogBoxDisplay>();
        spriteContainer.sprite = dialogBoxDisplay.GetSprite();
    }

    // Start is called before the first frame update
    void Awake()
    {
        dialogBoxDisplay = GetComponent<DialogBoxDisplay>();
        // Getting to correct child
        // Vet genuint inte varför jag inte bara la skriptet PÅ spriten direkt, men pallar inte göra om
        Transform dialog = transform.Find("Dialog");
        if (dialog != null)
        {
            Transform imageBoxTransform = dialog.Find("ImageBox");
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
        if (dialogBoxDisplay == null)
        {
            Debug.LogError("dialogBoxDisplay not found!");
        }
        if (dialogBoxDisplay.GetSprite() != null && spriteContainer != null)
        {
            spriteContainer.sprite = dialogBoxDisplay.GetSprite();
        }
        else if (dialogBoxDisplay.GetSprite() == null)
        {
            Debug.LogError("dialogSprite == null");
        }
        else if (spriteContainer == null)
        {
            Debug.LogError("spriteContainer == null");
        }
    }
}
