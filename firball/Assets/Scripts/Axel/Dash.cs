using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
[CreateAssetMenu]
public class Dash : Ability
{
    public float dashVelocity;

    public override void Activate(GameObject parent)
    {
        Debug.Log("dash påbörjas");
        InputSystemController movement = parent.GetComponent<InputSystemController>();
        
        float movementSpeed = movement.GetPlayerMovementSpeed();
        float movementDirection = movement.GetPlayerMovementDirection();
        bool isFacingRight = movement.GetIsFacingRight();
        



        AbilityHolder abilityHolder = parent.GetComponent<AbilityHolder>();
        float activeTime = abilityHolder.GetActiveTime();
        //AbilityHolder.AbilityState abilityState = abilityHolder.state;

        Debug.Log("mspeed " + movementSpeed + " mdirection " + movementDirection + " time " + activeTime);
        if (activeTime > 0 )
        {
            movement.SetPlayerMovementSpeed(dashVelocity * movementSpeed);
            //if (movementDirection == 0)
            //{
            //tänker att här får jag göra så att den kan dasha även om man står still.
            //}
        }
        else
        {
            movement.SetPlayerMovementSpeed(movementSpeed / dashVelocity);
        }
        
            
        
       
           
       
        
            //movement.playerMovementSpeed = movementSpeed;
        
        
    }
}
