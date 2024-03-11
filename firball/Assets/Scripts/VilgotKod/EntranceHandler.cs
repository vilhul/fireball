using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntranceHandler : MonoBehaviour
{

    private GameObject player;
    [SerializeField] private EntranceDataSO entranceDataSO;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("loaded");
    }

    private void Start()
    {
        if (InputSystemController.nextEntranceName != string.Empty)
        {
            player.transform.position = transform.position;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!InputSystemController.isInEntrance)
        {

            InputSystemController.isInEntrance = true;
            InputSystemController.nextEntranceName = entranceDataSO.nextEntranceName;

            Debug.Log("loading");
            SceneManager.LoadScene(entranceDataSO.nextRoom.name, LoadSceneMode.Additive);
            Debug.Log("unloading");
            SceneManager.UnloadSceneAsync(entranceDataSO.thisRoom.name);
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
