using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDesScript : MonoBehaviour
{
    CameraScript CameraScript;
    void Start()
    {
        GetComponent<CameraScript>();
    }

    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Car")
        {
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = new Vector3(0,-6,0);
            PlayerControllScript.Score3++;
        }
    }

}
