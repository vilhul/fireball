using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInteractionsMole : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask wall;
    private Vector2 groundCheckSize = new Vector2(0.5f, 0.1f);
    EnemyMovementMole emm;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        emm = GetComponentInParent<EnemyMovementMole>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.gameObject.layer == 6 || col.CompareTag("Enemy")) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, emm.jumpingPower);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(groundCheck.position, groundCheckSize);
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0f, wall);
    }
}
