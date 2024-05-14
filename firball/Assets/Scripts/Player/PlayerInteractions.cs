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
            // Goomba
            if(col.gameObject.GetComponent<EnemyMovementGoomba>()) // nödlösning
            {
                col.gameObject.GetComponent<EnemyMovementGoomba>().ToggleIsBeingHit();
                col.gameObject.GetComponent<EnemyDamageGoomba>().UpdateHealtbar();
            }

            // Mole
            if(col.gameObject.GetComponent <EnemyMovementMole>())
            {
                col.gameObject.GetComponent<EnemyMovementMole>().ToggleIsBeingHit();
                col.gameObject.GetComponent<EnemyDamageMole>().UpdateHealtbar();
            }

            // Robot 
            if (col.gameObject.gameObject.GetComponent<EnemyMovementRobot>())
            {
                col.gameObject.GetComponent<EnemyMovementRobot>().ToggleIsBeingHit();
                col.gameObject.GetComponent<EnemyDamageRobot>().UpdateHealtbar();
            }
            col.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(pushForceX, pushForceY));
            
        } //Vänster
        else if (col.gameObject.transform.position.x <= transform.position.x && col.gameObject.transform.CompareTag("Enemy"))
        {
            // Player
            StartCoroutine(HitTimeout());
            rb.velocity = new Vector2(0f, 0f);
            rb.AddForce(new Vector2(pushForceX, pushForceY));

            // Enemy
            if (col.gameObject.GetComponent<EnemyMovementGoomba>()) // nödlösning
            {
                col.gameObject.GetComponent<EnemyMovementGoomba>().ToggleIsBeingHit();
                col.gameObject.GetComponent<EnemyDamageGoomba>().UpdateHealtbar();
            }
            col.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-pushForceX, pushForceY));
        }
    }
}
//https://www.youtube.com/watch?v=1E8AI5UgmAw slopes
// https://www.youtube.com/watch?v=B34iq4O5ZYI Raycast tutorial