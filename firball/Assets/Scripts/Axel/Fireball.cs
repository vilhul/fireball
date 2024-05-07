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
        //Instantierar en eldboll och hämtar ariabler
        GameObject fireball = Instantiate(fireballProjectile, parent.transform.position, Quaternion.identity); ;
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        InputSystemController playerMovement = parent.GetComponent<InputSystemController>();
        bool isFacingRight = playerMovement.GetIsFacingRight();
        
        //skapar eldboll åt höger eller åt vänster framför spelaren
        if (isFacingRight)
        {
            rb.velocity = parent.transform.right * fireballSpeed;
            fireball.transform.position = new Vector3(fireball.transform.position.x + 1f, fireball.transform.position.y, fireball.transform.position.z);
                
        }
        else
        {
            rb.velocity = -parent.transform.right * fireballSpeed;
            fireball.transform.SetPositionAndRotation(new Vector3(fireball.transform.position.x - 1f, fireball.transform.position.y, fireball.transform.position.z), Quaternion.Euler(0,180,0));
        }
        //bör göra ett nytt script i eldbollen som säger att den bör despawna efter ett tag
    }
}
