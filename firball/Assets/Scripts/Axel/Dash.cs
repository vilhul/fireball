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
        //h�mtar scriptet playerInput (som �r av typen InputSystemController)
        movement = parent.GetComponent<InputSystemController>();
        //h�mtar variabler som beh�vs fr�n playerMovement
        movementSpeed = movement.GetPlayerMovementSpeed();
        movementDirection = movement.GetPlayerMovementDirection();
        isFacingRight = movement.GetIsFacingRight();

        
        //multiplicerar hastigheten med dashvelocity �nda till deactivate
        movement.SetPlayerMovementSpeed(dashVelocity * movementSpeed);

        //if (movementDirection == 0)
        //{
        //t�nker att h�r f�r jag g�ra s� att den kan dasha �ven om man st�r still.
        //}
    }

    public override void Deactivate(GameObject parent)
    {
        movement.SetPlayerMovementSpeed(movementSpeed);
    }
}
