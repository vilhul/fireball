using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicMovement_Goomba : MonoBehaviour
{
    public Transform player;
    private float speed = 3f;
    private bool isFacingRight = true;
    public float hp = 100f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform frontSideCheck;
    [SerializeField] private Transform walkableSpace;
    [SerializeField] private Transform head;
    [SerializeField] private LayerMask wall;
    [SerializeField] private LayerMask playerLayer;

    void Update()
    {
        WallCheck();
        FloorCheck();
        KillCheck();
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

    private void KillCheck()
    {
        if (IsTouched())
        {
            hp = 0f;
        }
        if ((hp <= 0f))
        {
            Destroy(gameObject);
        }
    }
    private bool IsTouched()
    {
        return Physics2D.OverlapBox(head.position, new Vector2(0.5f, 0.1f), 0f, playerLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
