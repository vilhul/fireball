using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Fireball : Ability
{
    [SerializeField] GameObject fireballProjectile;
    [SerializeField] float fireballSpeed = 10f;
    
    public override void Activate(GameObject parent)
    {
        GameObject fireball = Instantiate(fireballProjectile, parent.transform.position, Quaternion.identity);

        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();

        if (rb != null )
        {
            rb.velocity = parent.transform.right * fireballSpeed;
        }else
        {
            Debug.LogError("Fireball prefab saknar Rigidbody2D-komponent!");
        }
    }
}
