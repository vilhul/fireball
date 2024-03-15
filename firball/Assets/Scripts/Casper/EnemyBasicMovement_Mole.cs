using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicMovement_Mole : MonoBehaviour
{

    private float speed = 300f;
    private float jumpingPower = 20f;
    private bool isFacingRight = false;
    Vector3 mousePosition;
    Vector2 direction;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform frontSideCheck;
    [SerializeField] private LayerMask wall; 

    void Update()
    {
        //MouseCheck();
        mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        mousePosition.z = 0f;
        direction = mousePosition - transform.position;
        direction.y = 0f;
    }

    private void FixedUpdate()
    {
        if(!(direction.magnitude < 1))
        {
            rb.velocity = direction.normalized * Time.deltaTime * speed;
        } else { rb.velocity = new Vector2(); }
    }

    private void MouseCheck()
    {
        if (isFacingRight)
        {
            rb.velocity = new Vector2(speed, 0f);
        }

        if (IsGrinding())
        {
            Flip();
            rb.velocity = new Vector2(0f, 0f);
        }

        if (!isFacingRight)
        {
            rb.velocity = new Vector2(-speed, 0f);
        }
    }

    private bool IsGrinding ()
    {
        return Physics2D.OverlapCircle(frontSideCheck.position, 0.2f, wall);
    }


    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
