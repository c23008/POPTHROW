using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGyroScript : MonoBehaviour
{
    Vector3 vector3;
    Gyroscope Gyroscope;
    bool rote;
    public bool active;
    public GameObject PlayerObj;
    public GameObject PlPosObj;
    PlayerControllScript playerControll;
    Vector3 pos;

    public void OnEnable()
    {
        PlayerObj = GameObject.FindWithTag("Player");
        playerControll = PlayerObj.GetComponent<PlayerControllScript>();
    }
    void Start()
    {
        Input.gyro.enabled = true;
        rote = true;
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        pos = PlayerObj.transform.position;
        PlPosObj.transform.position = new Vector3(pos.x, pos.y + 2.5f, pos.z);
        Time.timeScale = 1;
        vector3 = Input.acceleration;
        Gyroscope = Input.gyro;
        float pitch = -Input.gyro.rotationRate.x * Mathf.Rad2Deg;
        float yaw = Input.gyro.rotationRate.z * Mathf.Rad2Deg;
        float roll = -Input.gyro.rotationRate.y * Mathf.Rad2Deg;
        transform.Rotate(new Vector3(pitch / 10, roll / 10, 0));
        if (rote == true)
        {
            transform.Rotate(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), 0f);
        }

        if(active == false)
        {
            //transform.rotation = Quaternion.Euler(20, -135, 3);
            active = true;
        }
        
    }
}
