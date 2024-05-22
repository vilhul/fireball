using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerNpcInteract : MonoBehaviour
{
    [SerializeField] float maxInteractionDistance = 0.5f;
    InputSystemController playerMovement;
    Transform playerTransform;
    DialogLoader dialogLoader;
    LayerMask npcLayer;
    // Start is called before the first frame update
    void Start()
    {
        npcLayer = LayerMask.GetMask("Npc");
        playerTransform = transform;
        playerMovement = GetComponent<InputSystemController>();
    }

    List<GameObject> GetNpcsInRange()
    {
        RaycastHit2D[] foundNpcs;
        // if facing right
        if (playerMovement.GetIsFacingRight())
        {
            foundNpcs = Physics2D.RaycastAll(transform.position, transform.right, maxInteractionDistance, npcLayer);
        }
        // if facing left
        else
        {
            foundNpcs = Physics2D.RaycastAll(transform.position, -transform.right, maxInteractionDistance, npcLayer);
        }

        List<GameObject> npcs = new List<GameObject>();
        foreach (RaycastHit2D foundNpc in foundNpcs)
        {
            npcs.Add(foundNpc.collider.gameObject);
        }
        return npcs;
    }

    // Update is called once per frame
    void Update()
    {
        // Player presses interact key
        if (Input.GetKeyDown(KeyCode.E) && GameObject.FindGameObjectWithTag("Dialog") == null)
        {
            List<GameObject> npcs = GetNpcsInRange();

            foreach (GameObject npc in npcs)
            {
                if (npc.GetComponent<DialogLoader>().GetDialogToLoad() != null)
                {
                    npc.GetComponent<DialogLoader>().LoadDialog();
                    break;
                }   
                //Debug.Log("Hit Npc: " + npc.name);
            }
            npcs.Clear();
        }
    }
}
