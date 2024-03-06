using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewInputSystem : MonoBehaviour
{
    
    public float playerMovementSpeed = 5f;
    public Vector2 moveInput;

    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        Vector2 moveDirection = new Vector2(moveInput.x, 0).normalized;
        transform.Translate(moveDirection * playerMovementSpeed * Time.deltaTime);
    }

    public void MovePlayer(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}
