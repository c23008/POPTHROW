using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMoveScript : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject[] wheel;
    public float DesTime;
    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        transform.Translate(0, 0, 0.1f);
        wheel[0].transform.Rotate(5, 0, 0);
        wheel[1].transform.Rotate(5, 0, 0);
        wheel[2].transform.Rotate(-5, 0, 0);
        wheel[3].transform.Rotate(-5, 0, 0);
        DesTime += Time.deltaTime;
        if(DesTime >= 15)
        {
            Destroy(gameObject);
        }
    }
}
