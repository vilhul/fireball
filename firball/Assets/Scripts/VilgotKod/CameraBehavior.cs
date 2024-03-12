using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{

    private Array roomBorders;
    private GameObject player;
    private Camera mainCamera;
    private float cameraWidth;
    private class ExceedingBorderStatus
    {
        public bool left = false;
        public bool up = false;
        public bool right = false;
        public bool down = false;
    }
    ExceedingBorderStatus exceedingBorderStatus = new ExceedingBorderStatus();

    public void UpdateRoomBorders()
    {
        roomBorders = GameObject.FindGameObjectsWithTag("RoomBorder");
    }


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
        foreach(float borderValue in FindExceedingBorders() )
        {
            Debug.Log(borderValue);
        }
    }


    private List<float> FindExceedingBorders()
    {
        List<float> exceedingBorderValues = new List<float> ();

        foreach (GameObject roomBorder in roomBorders)
        {
            if(roomBorder.transform.position.x > player.transform.position.x)
            {
                //bordern är höger om spelaren
                if ((roomBorder.transform.position.x - player.transform.position.x) > cameraWidth / 2)
                {
                    //bordern är utanför kamerans kant (åt höger)
                } else
                {
                    //bordern är innanför kamerans kant (åt höger)
                }
            }

            if(roomBorder.transform.position.x < player.transform.position.x)
            {
                //bordern är vänster om spelaren
            }


        }

        return exceedingBorderValues;
    }
}
