using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class EffectScrpt : MonoBehaviour
{
    public GameObject effect;
    public AudioSource ShotSound;
    PlayerControllScript playerCon;
    public GameObject Player;
    
    void Start()
    {
        effect.SetActive(false);
        Player = GameObject.FindWithTag("Player");
        playerCon = Player.GetComponent<PlayerControllScript>();
    }

    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            OnEffect();
        }
        
    }

    public void OnEffect()
    {
        if (playerCon.Shotbool == true)
        {
            ShotSound.PlayOneShot(ShotSound.clip);
            effect.SetActive(true);
            Invoke("Stop", 1);
        }
    }
    void Stop()
    {
        effect.SetActive(false);
        ShotSound.Stop();
        playerCon.Shotbool = false;
    }
}
