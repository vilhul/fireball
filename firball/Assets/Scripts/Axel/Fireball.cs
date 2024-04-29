using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
[CreateAssetMenu]
public class Fireball : Ability
{
    [SerializeField] GameObject fireballProjectile;
    [SerializeField] float fireballSpeed = 10f;
    
    public override void Activate(GameObject parent)
    {
        GameObject fireball = Instantiate(fireballProjectile, parent.transform.position, Quaternion.identity); ;
        InputSystemController movement = parent.GetComponent<InputSystemController>();
        bool isFacingRight = movement.GetIsFacingRight();
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        
        if (rb != null )
        {
            if (isFacingRight)
            {
                rb.velocity = parent.transform.right * fireballSpeed;
                fireball.transform.position = new Vector3(fireball.transform.position.x + 1f, fireball.transform.position.y, fireball.transform.position.z);
                
            }
            else
            {
                rb.velocity = -parent.transform.right * fireballSpeed;
                fireball.transform.position = new Vector3(fireball.transform.position.x - 1f, fireball.transform.position.y, fireball.transform.position.z);
                fireball.transform.rotation = Quaternion.Euler(0,180,0);
            }
        }else
        {
            Debug.LogError("Fireball prefab saknar Rigidbody2D-komponent!");
        }
    }
}
