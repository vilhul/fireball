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
        Debug.Log("dash p�b�rjas");
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
            //t�nker att h�r f�r jag g�ra s� att den kan dasha �ven om man st�r still.
            //}
        }
        else
        {
            movement.SetPlayerMovementSpeed(movementSpeed / dashVelocity);
        }
        
            
        
       
           
       
        
            //movement.playerMovementSpeed = movementSpeed;
        
        
    }
}
