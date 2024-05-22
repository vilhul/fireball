using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterChangerManager : MonoBehaviour
{
    [SerializeField] GameObject spriteDisplayer;
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite [] spriteList;
    int spriteIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
       spriteRenderer = spriteDisplayer.GetComponent<SpriteRenderer>();
       spriteRenderer.sprite = spriteList[spriteIndex];
    }

    // Update is called once per frame
    void Update()
    {
     if(spriteIndex >= spriteList.Length - 1) 
        {
            spriteIndex = 0;
        }   
    }

    public void ActivatePlayerSpriteChange()
    {
        Debug.Log("Clickad");
        spriteIndex++;
        Debug.Log(spriteIndex);
        spriteRenderer.sprite = spriteList[spriteIndex];
    }       
}
