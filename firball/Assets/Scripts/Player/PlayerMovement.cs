using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemController : MonoBehaviour
{
    public Rigidbody2D PlayerRb;

    //vilgot
    public static bool isInEntrance = false;
    public static bool hasExitedOnce = false;
    public static string nextEntranceName = string.Empty;


    //Axel
    [Header("Movement")]
    private float playerMovementSpeed = 5f;
    private float playerMovementDirection;
    private bool isFacingRight = true;
    
    [Header("Jumping")]
    private float playerJumpStrength = 12f;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;


    [Header("GroundCheck")]
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.5f);
    public LayerMask groundLayer;



    // Start is called before the first frame update
    void Start()
    {
        source.PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerRb.velocity = new Vector2(playerMovementDirection * playerMovementSpeed, PlayerRb.velocity.y);
         

        if (playerMovementDirection >= 0)
        {
            source.volume = 0;
        }
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
        MoonWalk(playerMovementDirection);

    }

    public void MoonWalk(float playerMovementDirection)
    {
        Debug.Log("moonwalk på g");
        if (playerMovementDirection < 0 && Keyboard.current.zKey.isPressed)
        {
            Debug.Log("spelar ljud");
            source.volume = 1;
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
            //Debug.Log("På marken");
            return true;
        }
        //Debug.Log("Funktionen kallas");
        return false;

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

    
}
