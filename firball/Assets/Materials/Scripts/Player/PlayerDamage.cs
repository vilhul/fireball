using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [Header("Health")]
    public float hp = 100f;
    public float maxHp = 100f;

    void Update()
    {
        if ((hp <= 0f))
        {
            Destroy(gameObject);
        }
    }
}
