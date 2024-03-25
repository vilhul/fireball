using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicMovement_Goomba : MonoBehaviour
{

    private float speed = 3f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform frontSideCheck;
    [SerializeField] private Transform walkableSpace;
    [SerializeField] private LayerMask wall; 

    void Update()
    {
        WallCheck();
        FloorCheck();
    }

    private void WallCheck()
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

    private void FloorCheck()
    {
        if(!IsFloor())
        {
            Flip();
        }
    }
    private bool IsGrinding ()
    {
        return Physics2D.OverlapCircle(frontSideCheck.position, 0.2f, wall);
    }

    private bool IsFloor()
    {
        return Physics2D.OverlapCircle(walkableSpace.position, 0.2f, wall);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
