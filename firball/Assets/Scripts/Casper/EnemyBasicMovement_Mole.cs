using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyBasicMovement_Mole : MonoBehaviour
{

    private float speed = 10f;
    private float jumpingPower = 15f;
    Vector3 mousePosition;
    Vector2 direction;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform frontSideCheck;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask wall; 

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
    }

    private void MouseCheck()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = new Vector2(mousePosition.x - transform.position.x, 0f);
        if (IsGrinding() && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (direction.x < 0)
        {
            Vector3 localScale = transform.localScale;
            localScale.x = 1f;
            transform.localScale = localScale;
        } else
        {
            Vector3 localScale = transform.localScale;
            localScale.x = -1f;
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
