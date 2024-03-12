using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2BasicMovement : MonoBehaviour
{

    private float speed = 8f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform frontSideCheck;
    [SerializeField] private LayerMask wall; 

    // Update is called once per frame
    void Update()
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

        if(!isFacingRight)
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
