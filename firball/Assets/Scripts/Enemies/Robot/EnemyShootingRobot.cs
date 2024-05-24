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
    private bool animHasPlayed = false;
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
            if(timer > 0 && !animHasPlayed)
            {
                emr.animator.SetTrigger("SeeingPlayer");
                animHasPlayed = true;
            } 
            if(timer > 2.5f)
            {
                hasShot = false;
                timer = 0;
                animHasPlayed = false;
            }
            if(timer > 2.3f && !hasShot)
            {
                hasShot = true;
                Shoot();
            }
        } else
        {
            timer = 0;
            animHasPlayed = false;
            hasShot = false;
            emr.animator.StopPlayback();
        }
    }

    private void Shoot()
    {
        Instantiate(beem, beemPos.position, Quaternion.identity);
    }
}
