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



    //OKEJ IMORN SÅ SKA DU GÖRA EN FUNKTION HÄR SOM HANTERAR ALLT SOM HÄNDER NÄR ETT NYTT RUM LADDAS OCH PÅ SÅ SÄTT KAN DU FÅ DEN ATT BERÄKNA VAR KAMERAN BORDE SPAWNAS SÅ ATT DET BLIR RÄTT OCH LÄTT SOM EN PLÄTT!!!
    //DU ÄNDRADE DET FUNKAR TYP MEN INTE RIKTIGT DU LÖSER DET IMORN STUMPAN <3
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
                Debug.Log("för få roomborders");
            }
            if(roomBorders.Length > 2)
            {
                Debug.Log("för många roomborders");
            }
            return;
        }

        leftBottomBorder = roomBorders[0];
        rightTopBorder = roomBorders[1];
        if(leftBottomBorder.transform.position.x > rightTopBorder.transform.position.x)
        {
            leftBottomBorder = roomBorders[1];
            rightTopBorder = roomBorders[0];
        }

    }

    private void MoveCamera()
    {
        if(!IsPlayerNearLeftBorder() && !IsPlayerNearRightBorder())
        {
            FollowPlayerX();
        } else
        {
            if(IsPlayerNearLeftBorder())
            {
                transform.position = new Vector3(leftBottomBorder.transform.position.x - leftSideDistance, transform.position.y, transform.position.z);
            } else
            {
                if(IsPlayerNearRightBorder())
                {
                    transform.position = new Vector3(rightTopBorder.transform.position.x - rightSideDistance, transform.position.y, transform.position.z);
                }
            }
        }
        if(!IsPlayerNearTopBorder()  && !IsPlayerNearBottomBorder())
        {
            FollowPlayerY();
        }
        else
        {
            if (IsPlayerNearTopBorder())
            {
                transform.position = new Vector3(transform.position.x, rightTopBorder.transform.position.y - topSideDistance, transform.position.z);
            }
            else
            {
                if (IsPlayerNearBottomBorder())
                {
                    transform.position = new Vector3(transform.position.x, leftBottomBorder.transform.position.y - bottomSideDistance, transform.position.z);
                }
            }
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
