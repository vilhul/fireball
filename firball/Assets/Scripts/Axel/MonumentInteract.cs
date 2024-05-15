using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEngine.RuleTile.TilingRuleOutput; VAD ÄR DET HÄR???? DEN BARA SPAWNADE OCH FÖRSTÖRDE TRANSFORM FÖR MIG

public class MonumentInteract : MonoBehaviour
{
    private GameObject player;
    private Transform playerTransform;
    private GameObject interactIndicator;
    private float minDistForInteraction = 2f;
    [SerializeField] private Ability typeOfAbility;
    [SerializeField] private KeyCode assignToKey;
    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        interactIndicator = GameObject.Find("InteractIndicator");
    }

    void Update()
    {
        float distance = Vector3.Distance(playerTransform.position, transform.position);
        if(distance < minDistForInteraction)
        {
            interactIndicator.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                GivePlayerAbility(player);
            }
        }else
        {
            interactIndicator.SetActive(false);
        }
    }

    void GivePlayerAbility(GameObject player)
    {
        player.AddComponent<AbilityHolder>();
        player.GetComponent<AbilityHolder>().ability = typeOfAbility;
        player.GetComponent<AbilityHolder>().key = assignToKey;
    }
}
