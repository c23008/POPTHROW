using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeScript : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject ChengeCamera;
    public float directionY;
    public float directionX;
    Vector3 TouchPos;
    Vector3 EndPos;
    PlayerControllScript playerControll;
    public CameraGyroScript cameraGyro;
    public GameObject GoolPos;
    public GameObject PlayerPos;
    int test;

    void Start()
    {
        MainCamera.SetActive(true); ChengeCamera.SetActive(false);
        playerControll = GetComponent<PlayerControllScript>();
        GoolPos.SetActive(false);
        test = 0;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TouchPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        }
        if (Input.GetMouseButtonUp(0))
        {
            EndPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            directionY = TouchPos.y - EndPos.y;
            directionX = TouchPos.x - EndPos.x;
            if (directionY >= 40 && directionX < 30 && directionX > -30)
            {
                test++;
                MainCamera.SetActive(!MainCamera.activeSelf);
                ChengeCamera.SetActive(!ChengeCamera.activeSelf);
                cameraGyro.active = false;
            }
            else if (directionY <= -40 && directionX < 30 && directionX > -30)
            {
                test++;
                MainCamera.SetActive(!MainCamera.activeSelf);
                ChengeCamera.SetActive(!ChengeCamera.activeSelf);
                cameraGyro.active = false;
            }
        }
        if(cameraGyro.active == true)
        {
            GoolPos.SetActive(true);
            PlayerPos.SetActive(true);
        }
        else
        {
            GoolPos.SetActive(false);
            PlayerPos.SetActive(false);
        }
    }

}
