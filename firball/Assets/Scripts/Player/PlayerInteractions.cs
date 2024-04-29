using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Collider2D playerCollider;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] public bool isBeingHit = false;
    private float pushForceX = 150f;
    private float pushForceY = 200f;


    void Update()
    {

    }

    private IEnumerator HitTime()
    {
        Debug.Log("Väntar");
        yield return new WaitForSeconds(0.3f);
        isBeingHit = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        //Höger
        if (col.gameObject.transform.position.x >= transform.position.x && col.gameObject.transform.CompareTag("Enemy"))
        {
            isBeingHit = true;
            StartCoroutine(HitTime());

            rb.velocity = new Vector2(0f, 0f);
            rb.AddForce(new Vector2(-pushForceX, pushForceY));

            col.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(pushForceX, pushForceY));
        } //Vänster
        else if (col.gameObject.transform.position.x <= transform.position.x && col.gameObject.transform.CompareTag("Enemy"))
        {
            isBeingHit = true;
            StartCoroutine(HitTime());

            rb.velocity = new Vector2(0f, 0f);
            rb.AddForce(new Vector2(pushForceX, pushForceY));

            col.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-pushForceX, pushForceY));
        }
    }
}
