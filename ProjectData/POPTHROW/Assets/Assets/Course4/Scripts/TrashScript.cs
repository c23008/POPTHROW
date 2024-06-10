using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rot();
    }

    void Rot()
    {
        transform.Rotate(new Vector3(0.2f, 0.05f, 0f));
    }
}
