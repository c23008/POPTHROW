using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript2 : MonoBehaviour
{

    public GameObject[] cars;
    public float coolTime;
    public float count;
    void Start()
    {
        GameObject car = (GameObject)Instantiate(RamdamCar(), transform.position, transform.rotation);
        coolTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        coolTime += Time.deltaTime;
        if (coolTime >= count)
        {
            GameObject car = (GameObject)Instantiate(RamdamCar(), transform.position, transform.rotation);
            coolTime = 0;
        }
    }

    GameObject RamdamCar()
    {
        int index = Random.Range(0, cars.Length);
        return cars[index];
    }

}
