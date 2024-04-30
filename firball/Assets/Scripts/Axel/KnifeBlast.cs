using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class KnifeBlast : Ability
{
    [SerializeField] GameObject knifeProjectile;
    [SerializeField] float knifeSpeed = 10f;
    float horizontalOffset = 0.2f;
    float verticalOffset = 0.2f;

    public override void Activate(GameObject parent)
    {

        Vector3 spawnPosition;
        
        
        for (int i = 0; i < 5; i++)
        {
            spawnPosition = parent.transform.position + new Vector3(horizontalOffset * i, verticalOffset * i, 0f);

            GameObject knife = Instantiate(knifeProjectile, spawnPosition, Quaternion.Euler(0,0,-90));
            knife.transform.parent = parent.transform;
        }
        
    }
}
