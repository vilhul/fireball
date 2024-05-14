using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationsRobot : MonoBehaviour
{
    [SerializeField] Animator animator;
    private EnemyMovementRobot emr;
    void Start()
    {
        emr = GetComponent<EnemyMovementRobot>();
    }


}
