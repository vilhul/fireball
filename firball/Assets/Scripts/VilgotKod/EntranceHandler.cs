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
        Debug.Log("loaded");
    }

    private void Start()
    {
        //player.transform.position
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!InputSystemController.isInEntrance)
        {

            InputSystemController.isInEntrance = true;

            Debug.Log("loading");
            SceneManager.LoadScene(entranceDataSO.nextRoom.name, LoadSceneMode.Additive);
            Debug.Log("unloading");
            SceneManager.UnloadSceneAsync(entranceDataSO.thisRoom.name);
            player.transform.position = entranceDataSO.nextEntrance.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (InputSystemController.isInEntrance)
        {
           if(!InputSystemController.hasExitedOnce)
            {
                InputSystemController.hasExitedOnce = true;
            } else
            {
                InputSystemController.isInEntrance = false;
                InputSystemController.hasExitedOnce = false;
            }
        }
    }
}
