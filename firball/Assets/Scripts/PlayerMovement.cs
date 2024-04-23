using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemController : MonoBehaviour
{
    public Rigidbody2D rb;

    //vilgot
    public static bool isInEntrance = false;
    public static bool hasExitedOnce = false;
    public static string nextEntranceName = string.Empty;

    //casper 
    private bool isFacingRight = true;
    private float pushForceX = 200f;
    private float pushForceY = 250f;
    [SerializeField] private bool isBeingHit = false;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Transform rightSide;
    [SerializeField] private Transform leftSide;

    //Axel
    [Header("Movement")]
    private float playerMovementSpeed = 5f;
    private float playerMovementDirection;
    [Header("Jumping")]
    private float playerJumpStrength = 12f;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;

    //casper
    [Header("Health")]
    public float hp = 100f;
    public float maxHp = 100f;
    [SerializeField] FloatingHealthbar healthbar;
    [SerializeField] private Transform healthCanvas;

    [Header("GroundCheck")]
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.5f);
    public LayerMask groundLayer;



    // Start is called before the first frame update
    void Start()
    {
        healthbar.UpdateHealthbar(hp, maxHp);
        source.PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isBeingHit)
        {
            rb.velocity = new Vector2(playerMovementDirection * playerMovementSpeed, rb.velocity.y);
        }
         
        KillCheck();
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
            rb.velocity = new Vector2(rb.velocity.x, playerJumpStrength);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        //if (IsGrounded())
        //{
        //    if (context.performed)
        //    {
        //        //hold down space => full jump power
        //        rb.velocity = new Vector2(rb.velocity.x, playerJumpStrength);
        //    }
            //else if (context.canceled)
            //{
            //    //tap space => half jump power
            //    rb.velocity = new Vector2(rb.velocity.x, playerJumpStrength * 0.5f);
            //}
        //}
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

    private bool IsEnemyHit()
    {
        Debug.Log("HitEnemy triggerd");
        return Physics2D.OverlapBox(transform.position, new Vector2(1f, 2f), 0f, enemyLayer);
    }

    private bool IsRighthandSide()
    {
        return Physics2D.OverlapBox(rightSide.position, new Vector2(0.1f, 1f), 0f, enemyLayer);
    }

    private bool IsLefthandSide()
    {
        Debug.Log("LefthandSide triggerd");
        return Physics2D.OverlapBox(leftSide.position, new Vector2(-0.1f, 1f), 0f, enemyLayer);
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
    }

    // denna gör ingenting just nu men när i har en sprite som behöver flippas kan vi använda denhär:
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private IEnumerator HitTime()
    {
        yield return new WaitForSeconds(0.5f);
        isBeingHit = false;
    }

    private void KillCheck()
    {
        if (IsEnemyHit() && !isBeingHit && IsRighthandSide())
        {
            isBeingHit = true;
            //hp = hp - 25f;
            rb.velocity = new Vector2(0f, 0f);
            rb.AddForce(new Vector2(-pushForceX, pushForceY));
            StartCoroutine(HitTime());
        }

        if (IsEnemyHit() && !isBeingHit && IsLefthandSide())
        {
            isBeingHit = true;
            //hp = hp - 25f;
            rb.velocity = new Vector2(0f, 0f);
            rb.AddForce(new Vector2(pushForceX, pushForceY));
            StartCoroutine(HitTime());
        }

        healthbar.UpdateHealthbar(hp, maxHp);
        if ((hp <= 0f))
        {
            Destroy(gameObject);
        }
    }
}
