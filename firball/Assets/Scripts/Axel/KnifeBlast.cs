using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu]
public class KnifeBlast : Ability
{
    [SerializeField] GameObject knifeProjectile;
    [SerializeField] float knifeSpeed = 10f;
    bool isFacingRight;
    List<GameObject> knifeList;
    public override void Activate(GameObject parent)
    {
        InputSystemController playerMovement = parent.GetComponent<InputSystemController>();
        isFacingRight = playerMovement.GetIsFacingRight();
        Vector3 spawnPosition;
        knifeList.Clear();

        List<float> xPositions = new List<float> {0.85f, -0.5f, 0.6f, -1.2f, 0.0f };
        List<float> yPositions = new List<float> {-0.6f, -0.45f, 0.1f, 0.7f, 1.2f};

        for (int i = 0; i < 5; i++)
        {
            Debug.Log("Kör for loop " + i + " många gånger kvar");
            float xOffset = xPositions[i];
            int knifeRotation = 90;
            
            if (isFacingRight)
            {
                xOffset = -xPositions[i];
                knifeRotation = -90;
            }
            
            spawnPosition = parent.transform.position + new Vector3(xOffset, yPositions[i], 0f);

            GameObject knife = Instantiate(knifeProjectile, spawnPosition, Quaternion.Euler(0,0,knifeRotation));
            knife.transform.parent = parent.transform;
            knifeList.Add(knife);
        }
        
    }


    public override void Deactivate(GameObject parent)
    {
        Debug.Log(knifeList.Count);
       
        for (int i = 0; i < knifeList.Count; i++)
        {
            knifeList[i].AddComponent<Rigidbody2D>();
            Rigidbody2D rb = knifeList[i].GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            knifeList[i].transform.parent = null;
            if (isFacingRight)
            {
                rb.velocity = new Vector2(knifeSpeed, 0);
                //knifeList[i].transform.position = new Vector3(knifeList[i].transform.position.x + 1f, knifeList[i].transform.position.y, knifeList[i].transform.position.z);

            }
            else
            {
                Debug.Log("jag kollar åt vänster");
                rb.velocity = new Vector2(-knifeSpeed, 0);
                //knifeList[i].transform.SetPositionAndRotation(new Vector3(knifeList[i].transform.position.x - 1f, knifeList[i].transform.position.y, knifeList[i].transform.position.z), Quaternion.Euler(0, 180, 0));
            }

        }
        knifeList.Clear();
    }
    
        
    
}
