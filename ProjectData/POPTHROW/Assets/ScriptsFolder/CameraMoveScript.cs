using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveScript : MonoBehaviour
{
    public GameObject Gool;
    public GameObject mainCam;
    public GameObject Pl;
    CameraScript camScr;
    public Vector3 GoolPos;
    Vector3 StartPos;
    int Select = 0;
    public float speed;
    public float X;
    public float Y;
    public float Z;
    public void Awake()
    {
        StartPos = transform.position;
    }

    public void OnEnable()
    {
        transform.position = StartPos;
    }
    void Start()
    {
        GoolPos = new Vector3(Gool.transform.position.x + X, Gool.transform.position.y + Y, Gool.transform.position.z + Z);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, GoolPos, speed);
        transform.LookAt(Gool.transform.position);
    }
}
