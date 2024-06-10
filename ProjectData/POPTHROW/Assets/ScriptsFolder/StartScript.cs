using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    CameraScript cameraScript;
    public void Awake()
    {
        cameraScript = GetComponent<CameraScript>();
    }
    void Start()
    {
        Instan();
    }

    void Update()
    {
        
    }

    public void Instan()
    {
        if (SceneManager.GetActiveScene().name == "Course1")
        {
            Instantiate(cameraScript.Chara[0], new Vector3(0, 1.65f, 1), Quaternion.Euler(-45, 0, 180));
        }
        if (SceneManager.GetActiveScene().name == "Course2")
        {
            Instantiate(cameraScript.Chara[0], new Vector3(-2.25f, 0.5f, 0.15f), Quaternion.Euler(-45, 0, 180));
        }
        if (SceneManager.GetActiveScene().name == "Course3")
        {
            Instantiate(cameraScript.Chara[0], new Vector3(-19, 0.5f, -19.5f), Quaternion.Euler(-45, 0, 180));
        }
    }

}
