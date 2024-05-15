using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
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

    public void Take10Damage()
    {
        hp -= 10f;
    }

    public void Take25Damage()
    {
        hp -= 25f;
    }

    public void Take50Damage()
    {
        hp -= 50f;
    }

    public void DIE()
    {
        hp = 0f;
    }
}
