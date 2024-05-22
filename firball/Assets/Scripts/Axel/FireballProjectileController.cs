using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball1 : MonoBehaviour
{
    GameObject player;
    float maxDistance = 15f;
    float distance;
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
        if(collision.IsTouchingLayers(3))
        {
            Destroy(gameObject);
        }
    }
}
