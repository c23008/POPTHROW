using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearScript : MonoBehaviour
{
    public BoxCollider gool;
    public CapsuleCollider gool2;
    public AudioSource clear;
    public GameObject player;
    PlayerControllScript playerScr;
    bool clearbool = false;
    void Start()
    {
        clearbool = false;
    }

    void Update()
    {
        if(clearbool)
        {
            playerScr.grounded = 0;
            PlayerControllScript.charge = 0;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject;
            playerScr = player.GetComponent<PlayerControllScript>();
            clear.Play();
            Invoke("Clear", 2);
            clearbool = true;
        }
    }

    

    public void Clear()
    {
        if (SceneManager.GetActiveScene().name == "Course1")
        {
            SceneManager.LoadScene("Course2");
        }
        else if (SceneManager.GetActiveScene().name == "Course2")
        {
            SceneManager.LoadScene("Course3");
        }
        else if (SceneManager.GetActiveScene().name == "Course3")
        {
            SceneManager.LoadScene("Course4");
        }
        else if (SceneManager.GetActiveScene().name == "Course4")
        {
            SceneManager.LoadScene("End");
        }
    }

}
