using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementGoomba : MonoBehaviour
{
    private float speed = 3f;
    private bool isFacingRight = true;
    public float hp, maxHp = 100f;
    private PlayerInteractions pl;
    private bool isBeingHit = false;

    [SerializeField] private Rigidbody2D rb;
    

    [Header("Layers")]
    
    [SerializeField] private LayerMask playerLayer;

    [Header("Healthbar")]
    [SerializeField] private FloatingHealthbar healthbar;
    [SerializeField] public Transform healthCanvas;

    private void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player").transform.Find("EnvironmentCollider").gameObject.GetComponent<PlayerInteractions>();
        healthCanvas.GetComponent<Canvas>().enabled=false;
        healthbar.UpdateHealthbar(hp, maxHp);
    }

    void Update()
    {
        
        if (!isBeingHit)
        {
            Walk();
        }
        
        KillCheck();
        healthbar = GetComponentInChildren<FloatingHealthbar>();
    }

    private void Walk()
    {
        if (isFacingRight)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else if (!isFacingRight)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }


    private bool HitPlayer()
    {
        return Physics2D.OverlapBox(transform.position, new Vector2(0.8f, 1.7f), 0f, playerLayer);
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

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;

        Vector3 healtbarScale = healthCanvas.localScale;
        healtbarScale.x *= -1f;
        healthCanvas.localScale = healtbarScale;

    }

    public IEnumerator HitTimeout()
    {
        yield return new WaitForSeconds(0.3f);
        isBeingHit = false;
    }

    public void ToggleIsBeingHit()
    {
        isBeingHit = true;
        StartCoroutine(HitTimeout());
    }
}
