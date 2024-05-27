using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
//using static UnityEngine.RuleTile.TilingRuleOutput; VAD ÄR DET HÄR???? DEN BARA SPAWNADE OCH FÖRSTÖRDE TRANSFORM FÖR MIG

public class MonumentInteract : MonoBehaviour
{
    private GameObject player;
    private Transform playerTransform;
    //private GameObject interactIndicator;
    private readonly float minDistForInteraction = 2f;
    private Vector3 indicatorPos;
    private bool hasResetIndicatorPos = false;
    private bool playerHasClaimedAbility = false;
    [SerializeField] private Ability typeOfAbility;
    [SerializeField] private KeyCode assignToKey;
    //[SerializeField] private Sprite deActivatedMonumentSprite;
    [SerializeField] private Animator animatorOnTheMonument;
    [SerializeField] private GameObject interactIndicator;


    private void Start()
    {
        //Hämtar nödvändiga variabler
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        
        indicatorPos = interactIndicator.transform.position;
    }

    void Update()
    {
       MonumentIsInteractive(playerHasClaimedAbility);
    }

    void GivePlayerAbility(GameObject player)
    {
        //Ger spelaren abilityn som man väljer att monumentet ska ge
        AbilityHolder abilityHolder = player.AddComponent<AbilityHolder>();
        abilityHolder.ability = typeOfAbility;
        abilityHolder.key = assignToKey;
        playerHasClaimedAbility = true;
    }

    void MonumentIsInteractive(bool hasClaimedAbility)
    {
        if (!hasClaimedAbility) {
            //Om distans mellan spelare och monument är mindre än värdet vi satt, då körs funktionen
            float distance = Vector3.Distance(playerTransform.position, transform.position);
            if (distance < minDistForInteraction)
            {
                //sätter pos på indicator och visar den
                if (!hasResetIndicatorPos)
                {
                    interactIndicator.transform.position = indicatorPos;
                    hasResetIndicatorPos = true;
                }

                interactIndicator.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //om spelaren interactar får den abiltyn
                    GivePlayerAbility(player);
                }
            }
            else
            {
                //om distans är större än minimum så visas inte indicatorn
                interactIndicator.SetActive(false);
                hasResetIndicatorPos = false;
            }
        }else
        {
            interactIndicator.SetActive(false);
            animatorOnTheMonument.SetBool("PlayerHasClaimedAbility", true);
        }
    }
}
