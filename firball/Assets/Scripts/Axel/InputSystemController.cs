using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemController : MonoBehaviour
{
    public Rigidbody2D rb;


    [Header("Movement")]
    private float playerMovementSpeed = 5f;
    private float playerMovementDirection;
    [Header("Jumping")]
    private float playerJumpStrength = 10f;

    [Header("GroundCheck")]
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.5f);
    public LayerMask groundLayer;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(playerMovementDirection * playerMovementSpeed, rb.velocity.y);

    }

    public void Move(InputAction.CallbackContext context)
    {
        playerMovementDirection = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded())
        {
            if (context.performed)
            {
                //hold down space => full jump power
                rb.velocity = new Vector2(rb.velocity.x, playerJumpStrength);
            }
            else if (context.canceled)
            {
                //tap space => half jump power
                rb.velocity = new Vector2(rb.velocity.x, playerJumpStrength * 0.5f);
            }
        }
    }

    private bool isGrounded()
    {
        if (Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer));
        {
            return true;
        }
        return false;
        
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
    }
}
