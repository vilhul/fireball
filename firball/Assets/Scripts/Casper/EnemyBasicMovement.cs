using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // first tutorial
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 20f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform Enemy;
    [SerializeField] private LayerMask groundLayer;

    // second tutorial
    public GameObject pointA;
    public GameObject pointB;
    private Transform currentPoint;

    private void Start()
    {
        currentPoint = pointB.transform;
    }

    void Update()
    {
        //horizontal = Input.GetAxisRaw("Horizontal");


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();

        // second tutorial

        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0f);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0f);
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
        }
    }

    private void FixedUpdate()
    {
        //rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(Enemy.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}


// first tutorial https://www.youtube.com/watch?v=K1xZ-rycYY8
// secont tutorial https://www.youtube.com/watch?v=RuvfOl8HhhM fortsätt på 6:20