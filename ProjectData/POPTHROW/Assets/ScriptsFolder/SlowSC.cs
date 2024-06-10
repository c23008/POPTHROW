using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowSC : MonoBehaviour
{
    public GameObject playerOBJ;
    public GameObject chenge;
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        if (playerOBJ.activeSelf == false)
        {
            Time.timeScale = 0;
        }
        Vector3 dis = playerOBJ.transform.position - transform.position;
        float disX = Mathf.Abs(dis.x);
        float disY = Mathf.Abs(dis.y);
        float disZ = Mathf.Abs(dis.z);
        if (disX < 10 && disY < 10 && disZ < 10)
        {
            Time.timeScale = 0.5f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }
}
