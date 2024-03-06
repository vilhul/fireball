using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicMovement : MonoBehaviour
{
    private float horizontal; 
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;


    // Update is called once per frame
    private void Update() 
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }
}


// https://www.youtube.com/watch?v=K1xZ-rycYY8