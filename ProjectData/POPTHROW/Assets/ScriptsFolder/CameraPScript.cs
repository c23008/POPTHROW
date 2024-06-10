using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraPScript : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField, Range(0, 10)]
    private float camHeight = 5.0f;
    [SerializeField, Range(0, 10)]
    private float camDistance = 5.0f;
    //[SerializeField, Range(0, 10)]
    //private float camX = 5.0f;
    public GameObject Enpty;
    public CameraScript cameraScr;
    public GameObject Player;
    PlayerControllScript playerControll;
    bool ShotTest;
    Vector3 targetPos;
    Vector3 startPos;
    Quaternion cameraRote;
    void Start()
    {
        //transform.rotation = Quaternion.Euler(0,0, 0);
        cameraScr = Enpty.GetComponent<CameraScript>();
        transform.parent = Enpty.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.parent = Enpty.transform;
        target = Enpty.transform;
        playerControll = cameraScr.playerScript;
        //transform.position = target.position - (target.forward * camDistance) + new Vector3(0, -camHeight, 0);
        if(SceneManager.GetActiveScene().name == "Course1" || SceneManager.GetActiveScene().name == "Course2")
        {
            transform.position = target.position + (target.forward * camDistance) + new Vector3(0, -camHeight, 0);
        }
        else if(SceneManager.GetActiveScene().name == "Course3" || SceneManager.GetActiveScene().name == "Course4")
        {
            transform.position = target.position - (target.forward * camDistance) + new Vector3(0, -camHeight, 0);
        }
        transform.LookAt(target);
        if (playerControll.shotSwich == false )
        {
            
        }
        else
        {
            cameraRot();
            cameraPos();
            //transform.localPosition = new Vector3(-0.187f, -0.0719f, -0.334f);
            
        }
        /*float RoteX = transform.rotation.x;
        float RoteY = transform.rotation.y;
        float RoteZ = transform.rotation.z;
        if(RoteZ < -1)
        {
            transform.rotation = Quaternion.Euler(RoteX, RoteY, -RoteZ);
        }*/
    }
    public void cameraPos()
    {
        if (SceneManager.GetActiveScene().name == "Course3")
        {
            transform.localPosition = new Vector3(-0.187f, -0.0719f, -0.334f);
        }
        else if (SceneManager.GetActiveScene().name == "Course2")
        {
            transform.localPosition = new Vector3(0.002f, -0.07f, 0.39f);
        }
        else if (SceneManager.GetActiveScene().name == "Course1")
        {
            transform.localPosition = new Vector3(0.002f, -0.08f, 0.382f);
        }
        else if (SceneManager.GetActiveScene().name == "Course4")
        {
            transform.localPosition = new Vector3(-0.002f, -0.07f, -0.38f);
        }
    }
    public void cameraRot()
    {
        if (SceneManager.GetActiveScene().name == "Course3")
        {
            transform.localRotation = Quaternion.Euler(-25, 29, 0);
        }else if(SceneManager.GetActiveScene().name == "Course2")
        {
            transform.localRotation = Quaternion.Euler(-25, 180, 0);
        }else if(SceneManager.GetActiveScene().name == "Course1")
        {
            transform.localRotation = Quaternion.Euler(-25, 180, 0);
        }else if(SceneManager.GetActiveScene().name == "Course4")
        {
            transform.localRotation = Quaternion.Euler(205, 180, 180);
        }
    }
}
