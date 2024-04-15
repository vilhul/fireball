using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicMovement_Goomba : MonoBehaviour
{
    public Transform player;
    private float speed = 3f;
    private bool isFacingRight = true;
    public float hp, maxHp = 100f;
    private float pushForce = 1000f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform frontSideCheck;
    [SerializeField] private Transform walkableSpaceFront;
    [SerializeField] private Transform walkableSpaceBack;
    [SerializeField] private Transform head;
    [SerializeField] private LayerMask wall;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] FloatingHealthbar healthbar;
    [SerializeField] private Transform healthCanvas;

    private void Start()
    {
        healthCanvas.GetComponent<Canvas>().enabled=false;
        healthbar.UpdateHealthbar(hp, maxHp);
    }

    void Update()
    {
        WallCheck();
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

        if(!IsFloorBack() && !IsFloorFront())
        {
            //rb.velocity = 0f;
        }
    }

    private void PlayerCheck()
    {
        
        if (HitPlayer() && isFacingRight)
        {
            rb.velocity = new Vector2(0f, 0f);
            rb.AddForce(new Vector2(-pushForce,0));
            //Vänta
            Debug.Log("jag har väntat?");
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
        return Physics2D.OverlapCircle(frontSideCheck.position, 0.2f, playerLayer);
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
