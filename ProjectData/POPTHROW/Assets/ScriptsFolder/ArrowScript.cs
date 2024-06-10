using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    [Header("Empty‚ð“ü‚ê‚é")]public GameObject maincam;
    CameraScript camScr;
    GameObject Player;
    GameObject gool;
    Transform goolPos;

    void Start()
    {
        camScr = maincam.GetComponent<CameraScript>();
        gool = GameObject.FindWithTag("Gool");
        goolPos = gool.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Player = camScr.player;
        transform.position = Player.transform.position + new Vector3(0,0.1f,0);
        transform.LookAt(goolPos);
    }
}
