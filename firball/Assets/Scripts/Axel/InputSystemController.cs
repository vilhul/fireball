using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemController : MonoBehaviour
{
    public Rigidbody2D rb;
    private float playerMovementDirection;

    [SerializeField]
    private float playerMovementSpeed = 5f;
    [SerializeField]
    private float playerJumpStrength = 10f;
    

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

        if (context.performed)
        {
            if (rb.velocity.y == 0)
            {
                rb.AddForce(new Vector2(0, playerJumpStrength), ForceMode2D.Impulse);
            }
    }

}
}
