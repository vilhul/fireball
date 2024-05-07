using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInteractionsMole : MonoBehaviour
{
    [SerializeField] private Transform frontSideCheck;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask wall;
    EnemyMovementMole emm;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        emm = GetComponentInParent<EnemyMovementMole>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.gameObject.layer == 3 || col.CompareTag("Enemy")) && IsGrounded())
        {
            Debug.Log("Simon är Straight");
            rb.velocity = new Vector2(rb.velocity.x, emm.jumpingPower);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapBox(groundCheck.position, new Vector2(1f, 0.1f), 0f, wall);
    }
}
