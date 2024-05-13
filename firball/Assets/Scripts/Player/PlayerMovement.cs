using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemController : MonoBehaviour
{
    public Rigidbody2D PlayerRb;

    // Map stuff
    public static bool isInEntrance = false;
    public static bool hasExitedOnce = false;
    public static string nextEntranceName = string.Empty;

    private PlayerInteractions pl;

    [Header("Movement")]
    private float playerMovementSpeed = 5f;
    private float playerMovementDirection;
    private bool isFacingRight = true;

    
    [Header("Jumping")]
    private float playerJumpStrength = 12f;
    [SerializeField] Animator animator;


    [Header("GroundCheck")]
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.5f);
    public LayerMask groundLayer;

    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player").transform.Find("EnvironmentCollider").gameObject.GetComponent<PlayerInteractions>();

    }

    void Update()
    {
        if (!pl.isBeingHit)
        {
            PlayerRb.velocity = new Vector2(playerMovementDirection * playerMovementSpeed, PlayerRb.velocity.y);
        }
       
        UpdatePlayerJumpVariables();
        
    }

    public void Move(InputAction.CallbackContext context)
    {
        playerMovementDirection = context.ReadValue<Vector2>().x;
        animator.SetFloat("PlayerSpeed", Mathf.Abs(playerMovementDirection));
        if (Keyboard.current.dKey.isPressed && !isFacingRight)
        {
            Flip();
        }
        else if (Keyboard.current.aKey.isPressed && isFacingRight)
        {
            Flip();
        }

    }

    public void Jump(InputAction.CallbackContext context)
    {
        
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            PlayerRb.velocity = new Vector2(PlayerRb.velocity.x, playerJumpStrength);
        }

        if (Input.GetButtonUp("Jump") && PlayerRb.velocity.y > 0f)
        {
            PlayerRb.velocity = new Vector2(PlayerRb.velocity.x, PlayerRb.velocity.y * 0.5f);
        }

    }

    public bool IsGrounded()
    {
        if (Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer))
        {
            
            
            return true;
        }else if(PlayerRb.velocity.y > 0f && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("spelare är i luften");
            
        }

            
        //Debug.Log("Funktionen kallas");
        return false;

    }

    public void UpdatePlayerJumpVariables()
    {
        if(IsGrounded())
        {
            //Debug.Log("Spelare hoppar inte");
            animator.SetBool("PlayerJump", false);
        }
        
        if (PlayerRb.velocity.y > 0f && IsGrounded()==false) 
        {
            //Debug.Log("Spelaren hoppar uppåt");
            animator.SetBool("PlayerJump", true);
            animator.SetFloat("UpOrDown", 10f);
        }  
        else if (PlayerRb.velocity.y < 0f && IsGrounded() == false)
        {
            //Debug.Log("Spelare faller");
            animator.SetFloat("UpOrDown", -1f);
        }
        else
        {
            //Debug.Log("Spelare står still i y-led");
            animator.SetFloat("UpOrDown", 1f);
        }
        
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public float GetPlayerMovementSpeed()
    {
        return playerMovementSpeed;
    }

    public void SetPlayerMovementSpeed(float speed)
    {
        playerMovementSpeed = speed;
    }

    public float GetPlayerMovementDirection()
    {
        return playerMovementDirection;
    }

    public bool GetIsFacingRight()
    {
        return isFacingRight;
    }
}
