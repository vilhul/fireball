using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemController : MonoBehaviour
{
    public Rigidbody2D rb;

    //vilgot
    public static bool isInEntrance = false;
    public static bool hasExitedOnce = false;
    public static string nextEntranceName = string.Empty;



    [Header("Movement")]
    private float playerMovementSpeed = 5f;
    private float playerMovementDirection;
    [Header("Jumping")]
    private float playerJumpStrength = 12f;

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
            Debug.Log("På marken");
            return true;
        }
        Debug.Log("Funktionen kallas");
        return false;

    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
    }
}
