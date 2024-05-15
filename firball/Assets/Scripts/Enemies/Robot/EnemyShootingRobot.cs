using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingRobot : MonoBehaviour
{
    public GameObject beem;
    public Transform beemPos;

    private float timer;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance < 13)
        {
            timer += Time.deltaTime;
            if(timer > 1)
            {
                timer = 0;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Instantiate(beem, beemPos.position, Quaternion.identity);
    }
}
