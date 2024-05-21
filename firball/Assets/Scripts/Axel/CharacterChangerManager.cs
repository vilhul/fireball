using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterChangerManager : MonoBehaviour
{
    [SerializeField] GameObject spriteShower;
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite partygnome;

    // Start is called before the first frame update
    void Start()
    {
       spriteRenderer = spriteShower.GetComponent<SpriteRenderer>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivatePlayerSpriteChange()
    {
        Debug.Log("Clickad");
        spriteRenderer.sprite = partygnome;
    }       
}
