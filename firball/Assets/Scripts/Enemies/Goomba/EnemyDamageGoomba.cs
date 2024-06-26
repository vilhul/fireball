using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageGoomba : MonoBehaviour
{
    public float hp, maxHp = 100f;
    [SerializeField] private FloatingHealthbar healthbar;
    [SerializeField] public Transform healthCanvas;

    void Start()
    {
        healthCanvas.GetComponent<Canvas>().enabled = true;
        healthbar.UpdateHealthbar(hp, maxHp);
    }

    void Update()
    {
        healthbar = GetComponentInChildren<FloatingHealthbar>();

        if ((hp <= 0f))
        {
            Destroy(gameObject);
        }
    }

    public void UpdateGoombaHealtbar()
    {
        healthCanvas.GetComponent<Canvas>().enabled = true;
        healthbar.UpdateHealthbar(hp, maxHp);
    }
}
