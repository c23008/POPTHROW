using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    [SerializeField] Rigidbody RG;
    // Start is called before the first frame update
    void Start()
    {
        RG.AddForce(transform.forward * 10000);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
