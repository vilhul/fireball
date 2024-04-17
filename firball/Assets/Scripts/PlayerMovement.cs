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
        rb.velocity = new Vector2(playerMovementDirection * playerMovementSpeed, rb.velocity.y);
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
        MoonWalk(playerMovementDirection);

    }

    public void MoonWalk( float playerMovementDirection)
    {

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
            //Debug.Log("P� marken");
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

    // denna g�r ingenting just nu men n�r i har en sprite som beh�ver flippas kan vi anv�nda denh�r:
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        Vector3 healtbarScale = healthCanvas.localScale;
        healtbarScale.x *= -1f;
        transform.localScale = localScale;
        healthCanvas.localScale = healtbarScale;
    }

    private void KillCheck()
    {
        healthbar.UpdateHealthbar(hp, maxHp);
        if ((hp <= 0f))
        {
            Destroy(gameObject);
        }
    }
}
