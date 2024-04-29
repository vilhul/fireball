using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    private Camera mainCamera;
    private GameObject player;
    private GameObject[] roomBorders;
    private GameObject leftBottomBorder;
    private GameObject rightTopBorder;

    private float leftSideDistance;
    private float rightSideDistance;
    private float topSideDistance;
    private float bottomSideDistance;



    //OKEJ IMORN S� SKA DU G�RA EN FUNKTION H�R SOM HANTERAR ALLT SOM H�NDER N�R ETT NYTT RUM LADDAS OCH P� S� S�TT KAN DU F� DEN ATT BER�KNA VAR KAMERAN BORDE SPAWNAS S� ATT DET BLIR R�TT OCH L�TT SOM EN PL�TT!!!
    private void Start()
    {
        mainCamera = GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player");
        DetermineSideDistance();
    }

    private void Update()
    {
        MoveCamera();
    }

    public void UpdateRoomBorders()
    {
        Debug.Log("Updaterar RoomBorders");

        roomBorders = GameObject.FindGameObjectsWithTag("RoomBorder");
        if(roomBorders.Length != 2)
        {
            if(roomBorders.Length < 2)
            {
                Debug.Log("f�r f� roomborders");
            }
            if(roomBorders.Length > 2)
            {
                Debug.Log("f�r m�nga roomborders");
            }
            return;
        }

        leftBottomBorder = roomBorders[0];
        rightTopBorder = roomBorders[1];

    }

    private void MoveCamera()
    {
        if(!IsPlayerNearLeftBorder() && !IsPlayerNearRightBorder())
        {
            FollowPlayerX();
        }
        if(!IsPlayerNearTopBorder()  && !IsPlayerNearBottomBorder())
        {
            FollowPlayerY();
        }
    }


    private bool IsPlayerNearLeftBorder()
    {
        if(player.transform.position.x + leftSideDistance <= leftBottomBorder.transform.position.x)
        {
            return true;
        } else
        {
            return false;
        }
    }

    private bool IsPlayerNearRightBorder()
    {
        if(player.transform.position.x + rightSideDistance >= rightTopBorder.transform.position.x)
        {
            return true;
        } else
        {
            return false;
        }
    }

    private bool IsPlayerNearTopBorder()
    {
        if(player.transform.position.y + topSideDistance >= rightTopBorder.transform.position.y)
        {
            return true;
        } else
        {
            return false;
        }
    }

    private bool IsPlayerNearBottomBorder()
    {
        if(player.transform.position.y + bottomSideDistance <= leftBottomBorder.transform.position.y)
        {
            return true;
        } else
        {
            return false;
        }
    }


    private void DetermineSideDistance()
    {
        leftSideDistance = -mainCamera.orthographicSize * mainCamera.aspect;
        rightSideDistance = mainCamera.orthographicSize * mainCamera.aspect;
        topSideDistance = mainCamera.orthographicSize;
        bottomSideDistance = -mainCamera.orthographicSize;
    }



    public void FollowPlayerX()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }

    public void FollowPlayerY()
    {
        transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
    }
}
