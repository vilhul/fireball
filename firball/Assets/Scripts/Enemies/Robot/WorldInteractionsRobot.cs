using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInteractionsRobot : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Transform walkableSpaceFront;
    [SerializeField] private Transform walkableSpaceBack;
    [SerializeField] private LayerMask wall;
    private EnemyMovementRobot emr;

    void Start()
    {
        emr = transform.parent.GetComponent<EnemyMovementRobot>();
    }

    void Update()
    {
        FloorCheck();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 6)
        {
            emr.Flip();
        }

        if (col.CompareTag("Enemy"))
        {
            emr.Flip();
        }
    }
    private bool IsFloorFront()
    {
        return Physics2D.OverlapCircle(walkableSpaceFront.position, 0.4f, wall);
    }

    private bool IsFloorBack()
    {
        return Physics2D.OverlapCircle(walkableSpaceBack.position, 0.4f, wall);
    }

    private void FloorCheck()
    {
        if (!IsFloorFront() && IsFloorBack())
        {
            emr.Flip();
        }
    }
}
