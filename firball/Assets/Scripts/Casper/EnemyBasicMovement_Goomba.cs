using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicMovement_Goomba : MonoBehaviour
{
    private float speed = 3f;
    private bool isFacingRight = true;
    public float hp, maxHp = 100f;
    private float pushForceX = 50f;
    private float pushForceY = 150f;
    private bool isBeingHit = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform frontSideCheck;
    [SerializeField] private Transform walkableSpaceFront;
    [SerializeField] private Transform walkableSpaceBack;
    [SerializeField] private Transform head;
    [SerializeField] private LayerMask wall;
    [SerializeField] private LayerMask playerLayer;
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
        PlayerCheck();
        healthbar = GetComponentInChildren<FloatingHealthbar>();
    }

    private void WallCheck()
    {
        if (isFacingRight)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }

        if (IsGrinding())
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
        Debug.Log("väntat");
        isBeingHit = false;
    }

    private void PlayerCheck()
    {
        // träffad från vänster
        if (HitPlayer() && !isFacingRight && !isBeingHit)
        {
            isBeingHit = true;
            rb.velocity = new Vector2(0f, 0f);
            rb.AddForce(new Vector2(pushForceX,pushForceY));
            StartCoroutine(HitTime());
            Debug.Log("Enemy träffad vänster");
        }

        // träffad från höger
        if (HitPlayer() && isFacingRight && !isBeingHit)
        {
            isBeingHit = true;
            rb.velocity = new Vector2(0f, 0f);
            rb.AddForce(new Vector2(pushForceX, pushForceY));
            StartCoroutine(HitTime());
            Debug.Log("Enemy träffad höger");
        }
    }

    private void FloorCheck()
    {
        if(!IsFloorFront() && IsFloorBack())
        {
            Flip();
        }
    }

    private bool IsGrinding()
    {
        return Physics2D.OverlapCircle(frontSideCheck.position, 0.2f, wall);
    }

    public bool HitPlayer()
    {
        return Physics2D.OverlapBox(transform.position, new Vector2(0.8f, 1.7f), 0f, playerLayer);
        //return ( nånting || nånting
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
        if (HeadIsTouched())
        {
            ShowHealtbar();
            hp = 50f;
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
        Vector3 healtbarScale = healthCanvas.localScale;
        healtbarScale.x *= -1f;
        transform.localScale = localScale;
        healthCanvas.localScale = healtbarScale;
    }
}
