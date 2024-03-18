using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyBasicMovement_Mole : MonoBehaviour
{

    private float speed = 10f;
    private float jumpingPower = 15f;
    private float maxSpeed = 4f;
    Vector2 direction;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform frontSideCheck;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask wall;
    [SerializeField] private Transform Player;

    void Update()
    {
        MouseCheck();
    }

    private void FixedUpdate()
    {
        if(!(direction.magnitude < 1))
        {
            rb.velocity += speed * Time.deltaTime * direction.normalized;
        } else { rb.velocity = new Vector2(0, rb.velocity.y); }
        rb.velocity = new Vector2 (Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), rb.velocity.y);
    }

    private void MouseCheck()
    {
        direction = new Vector2(Player.position.x - transform.position.x, 0f);
        if (IsGrinding() && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (direction.x < 0)
        {
            // flips the charachter
            Vector3 localScale = transform.localScale;
            localScale.x = 0.6f;
            transform.localScale = localScale;
        } else
        {
            Vector3 localScale = transform.localScale;
            localScale.x = -0.6f;
            transform.localScale = localScale;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapBox(groundCheck.position, new Vector2(1f, 0.1f),0f, wall);
    }
    private bool IsGrinding ()
    {
        return Physics2D.OverlapCircle(frontSideCheck.position, 0.2f, wall);
    }


    //private void Flip()
    //{
    //    isFacingRight = !isFacingRight;
    //    Vector3 localScale = transform.localScale;
    //    localScale.x *= -1f;
    //    transform.localScale = localScale;
    //}
}
