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
        if (col.gameObject.layer == 3)
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
            emg.Flip();
        }
    }
}
