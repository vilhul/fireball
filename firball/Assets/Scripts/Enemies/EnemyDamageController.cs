using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageController : MonoBehaviour
{
    public float hp = 100f;
    public float maxHp = 100f;

    void Update()
    {
        if ((hp <= 0f))
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        Debug.Log("Fiende tog skada");
    }

    public void DIE()
    {
        hp = 0f;
    }
}