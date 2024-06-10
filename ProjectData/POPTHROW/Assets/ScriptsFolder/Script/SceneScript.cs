using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SceneScript : MonoBehaviour
{
    public AudioSource AS;
    public int score;
    public int highScore;
    public Text scoretxt;
    public GameObject[] Con;
    ResultScript result;
    private void Awake()
    {
        result = GetComponent<ResultScript>();
        highScore = score;
        if (score <= 3)
        {
            score = PlayerPrefs.GetInt("highScore");
        }
    }

    void Start()
    {
        Time.timeScale = 1;
        Con[0].SetActive(false);
        Con[1].SetActive(false);
        Con[2].SetActive(false);
        HighScore();
        Invoke("Score0", 0.3f);
        Physics.gravity = new Vector3(0, -9.81f, 0);
    }

    void Update()
    {
        scoretxt.text = "HighScore   " + score;
    }

    public void OnStartButton()
    {
        Invoke("OnStart", 1);
        AS.Play();
    }

    public void OnEndButton()
    {
        Invoke("OnEnd", 1);
        AS.Play();
    }

    void OnStart()
    {
        SceneManager.LoadScene("Course1");
    }

    void OnEnd()
    {
        Application.Quit();
    }

    void HighScore()
    {
        if (highScore > score)
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }

    public void Score0()
    {
        PlayerControllScript.Score1 = 1;
        PlayerControllScript.Score2 = 1;
        PlayerControllScript.Score3 = 1;
        PlayerControllScript.Score4 = 1;
    }

    public void ConFlg()
    {
        Con[0].SetActive(true);
        Con[1].SetActive(false);
        AS.Play();
    }

    public void ConButton()
    {
        Con[0].SetActive(false);
        Con[1].SetActive(true);
    }

    public void powerButton()
    {
        Con[1].SetActive(false);
        Con[2].SetActive(true);
    }

    public void CamButton()
    {
        Con[2].SetActive(false);
    }
}
