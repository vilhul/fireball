using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementRobot : MonoBehaviour
{
    private float speed = 3f;
    private bool isFacingRight = true;

    //private PlayerInteractions pl;
    private EnemyDamageRobot edg;
    private bool isBeingHit = false;
    [SerializeField] public Animator animator;

    [SerializeField] private Rigidbody2D rb;


    private void Start()
    {
        //pl = GameObject.FindGameObjectWithTag("Player").transform.Find("EnvironmentCollider").gameObject.GetComponent<PlayerInteractions>();
        edg = transform.GetComponent<EnemyDamageRobot>();
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
        animator.SetBool("Is walking", true);
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
