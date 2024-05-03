using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Collider2D playerCollider;
    [SerializeField] public bool isBeingHit = false;
    private float pushForceX = 150f;
    private float pushForceY = 200f;

    void Update()
    {

    }

    private IEnumerator HitTimeout()
    {
        isBeingHit = true;
        yield return new WaitForSeconds(0.3f);
        isBeingHit = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        //Höger
        if (col.gameObject.transform.position.x >= transform.position.x && col.gameObject.transform.CompareTag("Enemy"))
        {
            // Player
            StartCoroutine(HitTimeout());
            rb.velocity = new Vector2(0f, 0f);
            rb.AddForce(new Vector2(-pushForceX, pushForceY));

            // Enemy
            col.gameObject.GetComponent<EnemyMovementGoomba>().ToggleIsBeingHit();
            col.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(pushForceX, pushForceY));
            col.gameObject.GetComponent<EnemyDamageGoomba>().UpdateHealtbar();
        } //Vänster
        else if (col.gameObject.transform.position.x <= transform.position.x && col.gameObject.transform.CompareTag("Enemy"))
        {
            // Player
            StartCoroutine(HitTimeout());
            rb.velocity = new Vector2(0f, 0f);
            rb.AddForce(new Vector2(pushForceX, pushForceY));

            // Enemy
            col.gameObject.GetComponent<EnemyMovementGoomba>().ToggleIsBeingHit();
            col.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-pushForceX, pushForceY));
            col.gameObject.GetComponent<EnemyDamageGoomba>().UpdateHealtbar();
        }
    }
}
