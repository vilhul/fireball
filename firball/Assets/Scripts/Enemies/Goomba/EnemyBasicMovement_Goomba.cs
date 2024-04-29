using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicMovement_Goomba : MonoBehaviour
{
    private float speed = 3f;
    private bool isFacingRight = true;
    public float hp, maxHp = 100f;
    //private float pushForceX = 150f;
    //private float pushForceY = 250f;
    private PlayerInteractions pl;

    [SerializeField] private Rigidbody2D rb;


    [Header("Sides")]
    [SerializeField] private Transform frontSide;
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
        pl = GameObject.FindGameObjectWithTag("Player").transform.Find("EnvironmentCollider").gameObject.GetComponent<PlayerInteractions>();
        healthCanvas.GetComponent<Canvas>().enabled=false;
        healthbar.UpdateHealthbar(hp, maxHp);
    }

    void Update()
    {
        
        if (!pl.isBeingHit)
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


        if (HitPlayer())
        {
            ShowHealtbar();
        }
        if ((hp <= 0f))
        {
            Destroy(gameObject);
        }
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

    }
}
