using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindScript : MonoBehaviour
{
    public WindZone zone;
    public float windX = 0f;
    public float windY = 0f;
    public float windZ = 0f;
    void Start()
    {
        zone = GetComponent<WindZone>();
    }

    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        Rigidbody otherRigidbody = other.GetComponent<Rigidbody>();

        if (otherRigidbody != null)
        {
            otherRigidbody.AddForce(windX, windY, windZ, ForceMode.Force);
        }
    }
}
