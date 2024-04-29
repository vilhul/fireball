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
        emg = GameObject.FindGameObjectWithTag("Enemy").gameObject.GetComponent<EnemyMovementGoomba>();
    }

    void Update()
    {
        FloorCheck();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Enemy wall Enter " + col.name);
        emg.Flip();
        rb.velocity = new Vector2(0f, 0f);
    }
    private bool IsFloorFront()
    {
        return Physics2D.OverlapCircle(walkableSpaceFront.position, 0.2f, wall);
    }

    private bool IsFloorBack()
    {
        return Physics2D.OverlapCircle(walkableSpaceBack.position, 0.2f, wall);
    }

    private void FloorCheck()
    {
        if (!IsFloorFront() && IsFloorBack())
        {
            emg.Flip();
        }
    }
}
