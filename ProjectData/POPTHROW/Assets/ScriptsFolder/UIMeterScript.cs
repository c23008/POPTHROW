using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMeterScript : MonoBehaviour
{
    public Image mater;
    public float maxIMG = 30;
    public float minIMG = 0;
    public float powerIMG;
    public RectTransform powerMeterRect;
    public float meterPosX;

    void Start()
    {
       powerMeterRect = mater.GetComponent<RectTransform>();
    }
    void Update()
    {
        
        if(PlayerControllScript.chergeBool)
        {
            meterPosX -= 15;
        }
        
        /*else
        {
            meterPosX -= Time.deltaTime ;
        }*/
        powerIMG = PlayerControllScript.charge;
        powerMeterRect.sizeDelta = new Vector2 (900 - powerIMG * 30, 100);
        powerMeterRect.localPosition = new Vector3(80 - powerIMG * 15, -850, 0);
        if (PlayerControllScript.charge == 0)
        {
            powerMeterRect.localPosition = new Vector3(80, -850, 0);
        }
    }
}
