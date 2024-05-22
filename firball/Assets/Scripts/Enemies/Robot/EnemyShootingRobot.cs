using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingRobot : MonoBehaviour
{
    public GameObject beem;
    public Transform beemPos;

    private float timer;
    private GameObject player;
    private EnemyMovementRobot emr;
    private bool hasShot = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        emr = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyMovementRobot>();
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance < 13)
        {
            timer += Time.deltaTime;
            if(timer == 0)
            {
                emr.animator.SetBool("IsSeeingPlayer", true);
            } else if(timer > 2.4f)
            {
                timer = 0;
                hasShot = false;
                emr.animator.SetBool("IsSeeingPlayer", false);
            }
            if(timer > 2.2f && !hasShot)
            {
                hasShot = true;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Instantiate(beem, beemPos.position, Quaternion.identity);
    }
}
