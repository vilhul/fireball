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

    private class IsPlayerInsideCamera
    {
        public bool x = true;
        public bool y = true;
    }
    IsPlayerInsideCamera isPlayerInsideCamera = new IsPlayerInsideCamera();

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        cameraWidth = mainCamera.orthographicSize * 2f * mainCamera.aspect;
        Debug.Log(cameraWidth);

        player = GameObject.FindGameObjectWithTag("Player");

        UpdateCamera();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRoomBorders();
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


    public void UpdateCamera()
    {
        //kolla om spelaren �r utanf�r kameran och flytta kameran s� spelaren �r vid kanten av den (funkar bara f�r x-y nu, vet inte om den ens beh�vs?)
        if(player.transform.position.x > mainCamera.transform.position.x)
        {
            //h�ger p� sk�rmen
            if(player.transform.position.x > mainCamera.transform.position.x + cameraWidth/2)
            {
                mainCamera.transform.position = new Vector3(player.transform.position.x - cameraWidth/2, mainCamera.transform.position.y, mainCamera.transform.position.z);
            }
        }
        if(player.transform.position.x < mainCamera.transform.position.x)
        {
            //v�nster p� sk�rmen
            if(player.transform.position.x < mainCamera.transform.position.x - cameraWidth/2)
            {
                mainCamera.transform.position = new Vector3(player.transform.position.x + cameraWidth / 2, mainCamera.transform.position.y, mainCamera.transform.position.z);
            }
        }


        foreach (GameObject roomBorder in roomBorders)
        {
            if (roomBorder.transform.position.x > mainCamera.transform.position.x)
            {
                //den h�r bordern �r h�ger om kameran
                if (roomBorder.transform.position.x < mainCamera.transform.position.x + cameraWidth / 2)
                {
                    mainCamera.transform.position = new Vector3(roomBorder.transform.position.x - cameraWidth / 2, mainCamera.transform.position.y, mainCamera.transform.position.z);
                }
            }
            if (roomBorder.transform.position.x < mainCamera.transform.position.x)
            {
                //den h�r bordern �r v�nster om kameran
                if (roomBorder.transform.position.x < mainCamera.transform.position.x - cameraWidth/2)
                {
                    mainCamera.transform.position = new Vector3(roomBorder.transform.position.x + cameraWidth / 2, mainCamera.transform.position.y, mainCamera.transform.position.z);
                }
            }


            if (roomBorder.transform.position.y > mainCamera.transform.position.y)
            {
                //den h�r bordern �r ovanf�r kameran
                if (roomBorder.transform.position.y < mainCamera.transform.position.y + mainCamera.orthographicSize)
                {
                    mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, roomBorder.transform.position.y - mainCamera.orthographicSize, mainCamera.transform.position.z);
                }
            }
            if (roomBorder.transform.position.y < mainCamera.transform.position.y)
            {
                //den h�r bordern �r under kameran
                if (roomBorder.transform.position.y < mainCamera.transform.position.y - mainCamera.orthographicSize)
                {
                    mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, roomBorder.transform.position.y + mainCamera.orthographicSize, mainCamera.transform.position.z);
                }
            }
        }
    }

    public void UpdateRoomBorders()
    {
        //Debug.Log("updaterar room borders");
        roomBorders = GameObject.FindGameObjectsWithTag("RoomBorder");
    }
}
