using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntranceHandler : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private EntranceDataSO entranceDataSO;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(player);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       player.transform.position = entranceDataSO.nextEntrance.transform.position;
        
    }
}
