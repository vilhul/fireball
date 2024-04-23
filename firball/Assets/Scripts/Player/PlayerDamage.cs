using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [Header("Health")]
    public float hp = 100f;
    public float maxHp = 100f;
    [SerializeField] FloatingHealthbar healthbar;
    [SerializeField] private Transform healthCanvas;
    void Start()
    {
        healthbar.UpdateHealthbar(hp, maxHp);
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.UpdateHealthbar(hp, maxHp);
        if ((hp <= 0f))
        {
            Destroy(gameObject);
        }
    }
}
