using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntranceHandler : MonoBehaviour
{
    private Camera mainCamera;
    private GameObject player;
    [SerializeField] private EntranceDataSO entranceDataSO;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mainCamera = FindAnyObjectByType<Camera>();
        Debug.Log("loaded");
    }

    private void Start()
    {
        if (InputSystemController.nextEntranceName == entranceDataSO.name)
        {
            player.transform.position = transform.position;
        }
        if(mainCamera != null)
        {
            CameraBehavior cameraBehavior = mainCamera.GetComponent<CameraBehavior>();
            cameraBehavior.UpdateRoomBorders();
        } else
        {
            Debug.LogWarning("ingen kamera stumpan");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!collision.CompareTag("Player")) return;

        if(!InputSystemController.isInEntrance)
        {

            InputSystemController.isInEntrance = true;
            InputSystemController.nextEntranceName = entranceDataSO.nextEntranceName;

            Debug.Log("loading");
            SceneManager.UnloadSceneAsync(entranceDataSO.thisRoom.name);
            SceneManager.LoadScene(entranceDataSO.nextRoom.name, LoadSceneMode.Additive);
            Debug.Log("unloading");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

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
