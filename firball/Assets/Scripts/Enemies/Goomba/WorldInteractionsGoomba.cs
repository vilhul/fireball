using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInteractionsGoomba : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Transform walkableSpaceFront;
    [SerializeField] private Transform walkableSpaceBack;
    [SerializeField] private LayerMask wall;
    private EnemyMovementGoomba emg;
    private float groundCheckSize = 0.4f;


    void Start()
    {
        emg = transform.parent.GetComponent<EnemyMovementGoomba>();
    }

    void Update()
    {
        FloorCheck();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 6)
        {
            emg.Flip();
        }

        if (col.CompareTag("Enemy"))
        {
            emg.Flip();
        }
    }
    private bool IsFloorFront()
    {
        return Physics2D.OverlapCircle(walkableSpaceFront.position, groundCheckSize, wall);
    }

    private bool IsFloorBack()
    {
        return Physics2D.OverlapCircle(walkableSpaceBack.position, groundCheckSize, wall);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(walkableSpaceFront.position, groundCheckSize);
        Gizmos.DrawWireSphere(walkableSpaceBack.position, groundCheckSize);
    }

    private void FloorCheck()
    {
        if (!IsFloorFront() && IsFloorBack())
        {
            emg.Flip();
        }
    }
}
