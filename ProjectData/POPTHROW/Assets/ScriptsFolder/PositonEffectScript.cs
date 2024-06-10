using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositonEffectScript : MonoBehaviour
{
    public GameObject Effect;
    public CameraGyroScript CameraGyro;
    void Start()
    {
        Effect.SetActive(true);
    }

    void Update()
    {
        if(CameraGyro.active == true)
        {
            Effect.SetActive(true);
        }
    }
}
