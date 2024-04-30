using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
[CreateAssetMenu]
public class Dash : Ability
{
    [SerializeField] float dashVelocity;
    InputSystemController movement;
    float movementSpeed;
    float movementDirection;
    bool isFacingRight;

    public override void Activate(GameObject parent)
    {
        //hämtar scriptet playerInput (som är av typen InputSystemController)
        movement = parent.GetComponent<InputSystemController>();
        //hämtar variabler som behövs från playerMovement
        movementSpeed = movement.GetPlayerMovementSpeed();
        movementDirection = movement.GetPlayerMovementDirection();
        isFacingRight = movement.GetIsFacingRight();

        
        //multiplicerar hastigheten med dashvelocity ända till deactivate
        movement.SetPlayerMovementSpeed(dashVelocity * movementSpeed);

        //if (movementDirection == 0)
        //{
        //tänker att här får jag göra så att den kan dasha även om man står still.
        //}
    }

    public override void Deactivate(GameObject parent)
    {
        movement.SetPlayerMovementSpeed(movementSpeed);
    }
}
