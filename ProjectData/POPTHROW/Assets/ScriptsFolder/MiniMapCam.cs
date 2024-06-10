using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MiniMapCam : MonoBehaviour
{
    public GameObject mainCam;
    CameraScript cameraScript;
    public GameObject MiniMapPlayer;
    Vector3 playPos;
    Quaternion playRot;
    public GameObject[] Mini;
    public GameObject gool;
    public Camera miniCam;
    int miniNum;

    void Start()
    {
        cameraScript = mainCam.GetComponent<CameraScript>();
    }

    void Update()
    {
        miniNum = cameraScript.A;
        MiniChenge();
        MiniMapPlayer = cameraScript.player;
        playPos = MiniMapPlayer.transform.position;
        Mini[miniNum].transform.position = playPos;
        transform.position = new Vector3(playPos.x, playPos.y + 50, playPos.z);
        playRot = MiniMapPlayer.transform.rotation;
        Mini[miniNum].transform.rotation = Quaternion.Euler(90, MiniMapPlayer.transform.eulerAngles.z, -MiniMapPlayer.transform.eulerAngles.y) * Quaternion.Euler(0, 0, 180);

        transform.rotation = Mini[miniNum].transform.rotation * Quaternion.Euler(0, 0, 180);
    }

    public void MiniChenge()
    {
        if(miniNum == 0)
        {
            Mini[0].SetActive(true);
        }
        else
        {
            Mini[0].SetActive(false);
        }
        if(miniNum == 1)
        {
            Mini[1].SetActive(true);
        }
        else
        {
            Mini[1].SetActive(false);
        }
        if(miniNum == 2)
        {
            Mini[2].SetActive(true);
        }
        else
        {
            Mini[2].SetActive(false);
        }
    }

}
