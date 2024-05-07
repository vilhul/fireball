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
        //Instantierar en eldboll och h�mtar ariabler
        GameObject fireball = Instantiate(fireballProjectile, parent.transform.position, Quaternion.identity); ;
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        InputSystemController playerMovement = parent.GetComponent<InputSystemController>();
        bool isFacingRight = playerMovement.GetIsFacingRight();
        
        //skapar eldboll �t h�ger eller �t v�nster framf�r spelaren
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
        //b�r g�ra ett nytt script i eldbollen som s�ger att den b�r despawna efter ett tag
    }
}
