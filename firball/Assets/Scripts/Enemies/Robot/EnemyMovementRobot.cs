using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyMovementRobot : MonoBehaviour
{
    private float speed = 3f;
    private bool isFacingRight = true;

    private GameObject player;
    private EnemyDamageRobot edg;
    private bool isBeingHit = false; 
    [SerializeField] public Animator animator;

    [SerializeField] private Rigidbody2D rb;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        edg = transform.GetComponent<EnemyDamageRobot>();
    }

    void Update()
    {
        animator.SetFloat("WalkVelocity", Mathf.Abs(rb.velocity.x));
        if (!isBeingHit)
        {
            Walk();
        }

        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < 13)
        {
            if (!isBeingHit)
            {
                isBeingHit = true;
            }
            if (player.transform.position.x < transform.position.x && isFacingRight)
            {
                Flip();
            }
            if (player.transform.position.x > transform.position.x && !isFacingRight)
            {
                Flip();
            }
        } else { isBeingHit = false; }
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
        isBeingHit = true;
        yield return new WaitForSeconds(0.3f);
        isBeingHit = false;
    }

    public void ToggleIsBeingHit()
    {
        StartCoroutine(HitTimeout());
    }

    
}
