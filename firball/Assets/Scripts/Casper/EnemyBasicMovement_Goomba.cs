using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicMovement_Goomba : MonoBehaviour
{
    private float speed = 3f;
    private bool isFacingRight = true;
    public float hp, maxHp = 100f;
    private float pushForceX = 150f;
    private float pushForceY = 250f;
    private bool isBeingHit = false;


    [SerializeField] private Rigidbody2D rb;

    [Header("Sides")]
    [SerializeField] private Transform head;
    [SerializeField] private Transform frontSide;
    [SerializeField] private Transform rightSide;
    [SerializeField] private Transform leftSide;
    [SerializeField] private Transform walkableSpaceFront;
    [SerializeField] private Transform walkableSpaceBack;
    

    [Header("Layers")]
    [SerializeField] private LayerMask wall;
    [SerializeField] private LayerMask playerLayer;

    [Header("Healthbar")]
    [SerializeField] private FloatingHealthbar healthbar;
    [SerializeField] private Transform healthCanvas;

    private void Start()
    {
        healthCanvas.GetComponent<Canvas>().enabled=false;
        healthbar.UpdateHealthbar(hp, maxHp);
    }

    void Update()
    {
        if (!isBeingHit)
        {
            WallCheck();
        }
        FloorCheck();
        KillCheck();
        healthbar = GetComponentInChildren<FloatingHealthbar>();
    }

    private void WallCheck()
    {
        if (isFacingRight)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }

        if (IsFrontSide())
        {
            Flip();
            rb.velocity = new Vector2(0f, 0f);
        }

        if (!isFacingRight)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }

    private IEnumerator HitTime()
    {
        yield return new WaitForSeconds(0.5f);
        isBeingHit = false;
    }

    private void FloorCheck()
    {
        if(!IsFloorFront() && IsFloorBack())
        {
            Flip();
        }
    }

    private bool IsFrontSide()
    {
        return Physics2D.OverlapCircle(frontSide.position, 0.2f, wall);
    }

    private bool IsRightSide()
    {
        return Physics2D.OverlapBox(rightSide.position, new Vector2(0.1f, 1.6f), 0f, playerLayer);
    }

    private bool IsLeftSide()
    {
        return Physics2D.OverlapBox(leftSide.position, new Vector2(-0.1f, 1.6f), 0f, playerLayer);
    }

    private bool HitPlayer()
    {
        return Physics2D.OverlapBox(transform.position, new Vector2(0.8f, 1.7f), 0f, playerLayer);
    }

    private bool IsFloorFront()
    {
        return Physics2D.OverlapCircle(walkableSpaceFront.position, 0.2f, wall);
    }

    private bool IsFloorBack()
    {
        return Physics2D.OverlapCircle(walkableSpaceBack.position, 0.2f, wall);
    }

    private void KillCheck()
    {
        healthbar.UpdateHealthbar(hp, maxHp);

        // träffad från vänster
        //if (HitPlayer() && IsLeftSide() && !isBeingHit)
        //{
        //    isBeingHit = true;
        //    rb.velocity = new Vector2(0f, 0f);
        //    rb.AddForce(new Vector2(pushForceX, pushForceY));
        //    StartCoroutine(HitTime());
        //}

        //// träffad från höger
        //if (HitPlayer() && IsRightSide() && !isBeingHit)
        //{
        //    isBeingHit = true;
        //    rb.velocity = new Vector2(0f, 0f);
        //    rb.AddForce(new Vector2(-pushForceX, pushForceY));
        //    StartCoroutine(HitTime());
        //}

        if (HitPlayer())
        {
            ShowHealtbar();
        }
        if ((hp <= 0f))
        {
            Destroy(gameObject);
        }
    }
    private bool HeadIsTouched()
    {
        return Physics2D.OverlapBox(head.position, new Vector2(0.5f, 0.1f), 0f, playerLayer);
    }

    private void ShowHealtbar()
    {
        healthCanvas.GetComponent<Canvas>().enabled = true;
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;

        Vector3 healtbarScale = healthCanvas.localScale;
        healtbarScale.x *= -1f;
        healthCanvas.localScale = healtbarScale;

        rightSide.position = new Vector3((rightSide.position.x - transform.position.x) * -1f + transform.position.x, rightSide.position.y, 0f);

        leftSide.position = new Vector3((leftSide.position.x - transform.position.x) * -1f + transform.position.x, leftSide.position.y, 0f);
    }
}
