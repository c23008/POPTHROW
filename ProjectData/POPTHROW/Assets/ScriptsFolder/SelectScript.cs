using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectScript : MonoBehaviour
{
    public Text score;
    public AudioSource AS;
    public float timer;
    public float nowtimer;
    public GameObject Can;
    public GameObject startCam;
    public bool camPos;
    CameraMoveScript moveScr;
    void Start()
    {
        Application.targetFrameRate = 60;
        //GameObject.FindWithTag("Player");
        AS.Play();
        startCam.SetActive(true);
        Can.SetActive(false);
        moveScr = startCam.GetComponent<CameraMoveScript>();
    }

    private void Update()
    {
        tst2();
        if (startCam != null) return;
        else
        {
            Can.SetActive(true);
        }
        
    }

    

    public void tst2()
    {
        if (SceneManager.GetActiveScene().name == "Course1")
        {
            score.text = "��" + PlayerControllScript.Score1 + "�Ŗ�";
        }
        if (SceneManager.GetActiveScene().name == "Course2")
        {
            score.text = "��" + PlayerControllScript.Score2 + "�Ŗ�";
        }
        if (SceneManager.GetActiveScene().name == "Course3")
        {
            score.text = "��" + PlayerControllScript.Score3 + "�Ŗ�";
        }
        if (SceneManager.GetActiveScene().name == "Course4")
        {
            score.text = "��" + PlayerControllScript.Score4 + "�Ŗ�";
        }
    }

    public void Title()
    {
        SceneManager.LoadScene("Title");
    }
}
