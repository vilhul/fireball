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
        
        float movementSpeed = movement.playerMovementSpeed;
        float movementDirection = movement.playerMovementDirection;
        
        
        


        AbilityHolder abilityHolder = parent.GetComponent<AbilityHolder>();
        float activeTime = abilityHolder.activeTime;
        //AbilityHolder.AbilityState abilityState = abilityHolder.state;


        if (activeTime > 0 )
        {
            movement.playerMovementSpeed = movementDirection * dashVelocity;
        }
        else
        {
            //movement.playerMovementSpeed = movementSpeed/dashVelocity;
        }
        
            
        
       
           
       
        
            //movement.playerMovementSpeed = movementSpeed;
        
        
    }
}
