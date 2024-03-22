using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{

    public Array roomBorders;
    private GameObject player;
    private Camera mainCamera;
    private float cameraWidth;
    private class IsBorderInsideCamera
    {
        public bool left = true;
        public bool up = true;
        public bool right = true;
        public bool down = true;
    }
    IsBorderInsideCamera isBorderInsideCamera = new IsBorderInsideCamera();

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        cameraWidth = mainCamera.orthographicSize * 2f * mainCamera.aspect;
        Debug.Log(cameraWidth);

        player = GameObject.FindGameObjectWithTag("Player");

        UpdateRoomBorders();
    }

    // Update is called once per frame
    void Update()
    {
        FindExceedingBorders();
        MoveCamera();
    }

    private void FindExceedingBorders()
    {
        foreach (GameObject roomBorder in roomBorders)
        {
            if(roomBorder.transform.position.x > player.transform.position.x)
            {
                if ((roomBorder.transform.position.x - player.transform.position.x) < cameraWidth / 2)
                {
                    isBorderInsideCamera.right = true;
                } else
                {
                    isBorderInsideCamera.right = false;
                }
            }

            if(roomBorder.transform.position.x < player.transform.position.x)
            {
                if((player.transform.position.x - roomBorder.transform.position.x) < cameraWidth / 2)
                {
                    isBorderInsideCamera.left = true;
                } else
                {
                    isBorderInsideCamera.left = false;
                }
            }
            if (roomBorder.transform.position.y > player.transform.position.y)
            {
                if ((roomBorder.transform.position.y - player.transform.position.y) < mainCamera.orthographicSize)
                {
                    isBorderInsideCamera.up = true;
                }
                else
                {
                    isBorderInsideCamera.up = false;
                }
            }

            if (roomBorder.transform.position.y < player.transform.position.y)
            {
                if ((player.transform.position.y - roomBorder.transform.position.y) < mainCamera.orthographicSize)
                {
                    isBorderInsideCamera.down = true;
                }
                else
                {
                    isBorderInsideCamera.down = false;
                }
            }
        }
    }

    private void MoveCamera()
    {
        if(!(isBorderInsideCamera.right || isBorderInsideCamera.left))
        {
            mainCamera.transform.position = new Vector3(player.transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z);
        }
        if (!(isBorderInsideCamera.up || isBorderInsideCamera.down))
        {
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, player.transform.position.y, mainCamera.transform.position.z);
        }
    }

    public void UpdateRoomBorders()
    {
        roomBorders = GameObject.FindGameObjectsWithTag("RoomBorder");
    }
}
