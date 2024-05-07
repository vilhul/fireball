using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementGoomba : MonoBehaviour
{
    private float speed = 3f;
    private bool isFacingRight = true;
    
    private PlayerInteractions pl;
    private EnemyDamageGoomba edg;
    private bool isBeingHit = false;

    [SerializeField] private Rigidbody2D rb;
    

    private void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player").transform.Find("EnvironmentCollider").gameObject.GetComponent<PlayerInteractions>();
        edg = transform.GetComponent<EnemyDamageGoomba>(); 
    }

    void Update()
    {
        if (!isBeingHit)
        {
            Walk();
        }
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


    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;

        Vector3 healtbarScale = edg.healthCanvas.localScale;
        healtbarScale.x *= -1f;
        edg.healthCanvas.localScale = healtbarScale;
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
