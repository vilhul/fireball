using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballProjectileController : MonoBehaviour
{
    GameObject player;
    float maxDistance = 15f;
    float distance;
    EnemyDamageController enemyDamageController;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > maxDistance) { 
            Destroy(gameObject);
            Debug.Log("eldboll borde ha förstörts");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemyDamageController = collision.gameObject.GetComponent<EnemyDamageController>();
        if(collision.IsTouchingLayers(6))
        {
            //Om eldboll nuddar ground
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            //om eldboll nuddar fiende
            enemyDamageController.TakeDamage(25);
            Destroy(gameObject);
        }
    }
}
