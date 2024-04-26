using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Collider2D playerCollider;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private bool isBeingHit = false;
    private float pushForceX = 150f;
    private float pushForceY = 200f;


    void Update()
    {
        KillCheck();
    }
    private bool IsEnemyHit()
    {
        Debug.Log("HitEnemy triggerd");
        return Physics2D.OverlapBox(transform.position, new Vector2(1f, 2f), 0f, enemyLayer);
    }

    private IEnumerator HitTime()
    {
        yield return new WaitForSeconds(0.5f);
        isBeingHit = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Player collided with " + col.name);
        isBeingHit = true;

        //Höger
        if(col.gameObject.transform.position.x >= transform.position.x && col.gameObject.transform.CompareTag("Enemy"))
        {
            rb.velocity = new Vector2(0f, 0f);
            rb.AddForce(new Vector2(-pushForceX, pushForceY));

            col.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(pushForceX, pushForceY));
        } //Vänster
        else if (col.gameObject.transform.position.x <= transform.position.x && col.gameObject.transform.CompareTag("Enemy"))
        {
            rb.velocity = new Vector2(0f, 0f);
            rb.AddForce(new Vector2(pushForceX, pushForceY));

            col.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-pushForceX, pushForceY));
        }
    }

    void OnTriggerExit2D (Collider2D col)
    {
        Debug.Log("Player stopped coliding with " + col.name);
        isBeingHit = false;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Enemy"))
        {
            Debug.Log("Player träffad av en Enemy");

            foreach(ContactPoint2D PlayerCol in col.contacts)
            {
                Vector3 hitPoint = PlayerCol.point;
                hitPoint = new Vector3(pushForceX, pushForceY, hitPoint.z);
            }
        }
    }

    //private bool IsRighthandSide()
    //{
    //    return Physics2D.OverlapBox(rightSide.position, new Vector2(0.1f, 1f), 0f, enemyLayer);
    //}

    //private bool IsLefthandSide()
    //{
    //    Debug.Log("LefthandSide triggerd");
    //    return Physics2D.OverlapBox(leftSide.position, new Vector2(-0.1f, 1f), 0f, enemyLayer);
    //}
    private void KillCheck()
    {
        //if (IsEnemyHit() && !isBeingHit && IsRighthandSide())
        //{
        //    isBeingHit = true;
        //    //hp = hp - 25f;
        //    rb.velocity = new Vector2(0f, 0f);
        //    rb.AddForce(new Vector2(-pushForceX, pushForceY));
        //    StartCoroutine(HitTime());
        //}

        //if (IsEnemyHit() && !isBeingHit && IsLefthandSide())
        //{
        //    isBeingHit = true;
        //    //hp = hp - 25f;
        //    rb.velocity = new Vector2(0f, 0f);
        //    rb.AddForce(new Vector2(pushForceX, pushForceY));
        //    StartCoroutine(HitTime());
        //}


    }
}
