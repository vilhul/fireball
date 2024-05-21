using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderLogic : MonoBehaviour
{
    InputSystemController playerMovement;

    private void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<InputSystemController>();
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKey(KeyCode.W))
        {
            playerMovement.PlayerRb.velocity = new Vector2(playerMovement.PlayerRb.velocity.x, 5f);
        }
    }
}
