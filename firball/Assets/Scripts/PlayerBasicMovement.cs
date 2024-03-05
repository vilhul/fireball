using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBasicMovement : MonoBehaviour
{
    //[SerializeField]
    private float playerMovementSpeedMultiplier = 30f;
    private Rigidbody2D playerRigidbody;
    private float playerJumpForceMultiplier = 10f;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        bool verticalInput = Input.GetKeyDown(KeyCode.Space);

        if (verticalInput)
        {
            playerRigidbody.AddForce(Vector2.up * playerJumpForceMultiplier, ForceMode2D.Impulse);
        }

        Vector2 direction = new Vector2(horizontalInput, 0);
        transform.Translate(direction * playerMovementSpeedMultiplier * Time.deltaTime);

        if (Input.GetKey(KeyCode.R))
        {
            transform.position = (Vector2.zero);
        }
    }
}
