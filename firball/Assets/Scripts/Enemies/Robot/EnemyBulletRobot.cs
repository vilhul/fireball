using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletRobot : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    [SerializeField] private float force = 5;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 3)
        {
            Destroy(gameObject);
        }

        if (col.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerDamage>().Take10Damage();
            Destroy(gameObject);
        }
    }

}
