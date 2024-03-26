using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding; 

public class EnemyBasicMovementPathfinding_Mole : MonoBehaviour
{
    [Header("Pathfinding")]
    public Transform target;
    public float activateDistance = 50f;
    public float pathUpdateSeconds = 0.5f;

    [Header("Physics")]
    public float speed = 5f;
    public float hp = 100f;
    public float jumpingPower = 15f;
    public float nextWaypointDistance = 3f;
    [SerializeField] private Transform frontSideCheck;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform head;
    [SerializeField] private LayerMask wall;
    [SerializeField] private LayerMask playerLayer;

    [Header("Custom Behavior")]
    public bool followEnabled = true;
    public bool directionLookEnabled = true;

    [SerializeField] Vector3 startOffset;

    private Path path;
    private int currentWaypoint = 0;
    [SerializeField] public RaycastHit2D isGrounded;
    Seeker seeker;
    Rigidbody2D rb;

    private void Update()
    {
        if (IsGrinding() && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        KillCheck();
    }

    // början på kopierad kod
    public void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, pathUpdateSeconds);
    }
    private void FixedUpdate()
    {
        if (TargetInDistance() && followEnabled)
        {
            PathFollow();
        }
    }

    private void UpdatePath()
    {
        if (followEnabled && TargetInDistance() && seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    private void PathFollow()
    {
        if (path == null)
        {
            return;
        }

        // Reached end of path
        if (currentWaypoint >= path.vectorPath.Count)
        {
            return;
        }

        // See if colliding with anything
        startOffset = transform.position - new Vector3(0f, GetComponent<Collider2D>().bounds.extents.y, transform.position.z);
        isGrounded = Physics2D.Raycast(startOffset, -Vector3.up, 0.05f);

        // Direction Calculation
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed;

        // Movement
        rb.velocity = new Vector2(force.x, rb.velocity.y);

        // Next Waypoint
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        // Direction Graphics Handling
        if (directionLookEnabled)
        {
            if (rb.velocity.x > 0.05f)
            {
                transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else if (rb.velocity.x < -0.05f)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
    }

    private bool TargetInDistance()
    {
        return Vector2.Distance(transform.position, target.transform.position) < activateDistance;
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    //slut på kopierad kod
    //Killing the Enemy
    private void KillCheck()
    {
        if (IsTouched())
        {
            hp = 0f;
        }
        if ((hp <= 0f))
        {
            Destroy(gameObject);
        }
    }
    private bool IsTouched()
    {
        return Physics2D.OverlapBox(head.position, new Vector2(0.7f, 0.1f), 0f, playerLayer);
    }

    //Jump 
    private bool IsGrounded()
    {
        return Physics2D.OverlapBox(groundCheck.position, new Vector2(1f, 0.1f), 0f, wall);
    }
    private bool IsGrinding()
    {
        return Physics2D.OverlapCircle(frontSideCheck.position, 0.2f, wall);
    }
}
