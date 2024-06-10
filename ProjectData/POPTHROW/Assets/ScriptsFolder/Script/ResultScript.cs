using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultScript : MonoBehaviour
{
    public GameObject tittleButton;
    public Text FirstText;
    public Text SecondText;
    public Text ThirdText;
    public Text FourthText;
    public Text ResultText;
    public Text scoretxt;
    public int SCORE;
    public  AudioSource ScoreSound;
    public  AudioSource ButtonSound;
    public int course1score;
    public int course2score;
    public int course3score;
    public int course4score;
    void Start()
    {
        tittleButton.SetActive(false);
        StartCoroutine(result());
        ScoreSound = GetComponent<AudioSource>();
        course1score = PlayerControllScript.Score1 - 1;
        course2score = PlayerControllScript.Score2 - 1;
        course3score = PlayerControllScript.Score3 - 1;
        course4score = PlayerControllScript.Score4 - 1;
        SCORE = course1score +course2score +course3score + course4score;
        Time.timeScale = 1.0f;
    }
    void Update()
    {
        if (SCORE <= 3)
        {
            SCORE = PlayerPrefs.GetInt("highScore");
        }
        if (PlayerPrefs.GetInt("highScore") > SCORE)
        {
            PlayerPrefs.SetInt("highScore", SCORE);
        }
        if(PlayerPrefs.GetInt("highScore") <= 3)
        {
            PlayerPrefs.SetInt("highScore", SCORE);
        }
        PlayerPrefs.Save();
    }
    public void GoTittle()
    {
        SceneManager.LoadScene("Title");
    }
    IEnumerator result()
    {
        yield return new WaitForSeconds(1);
        FirstText.text = "Stage1:" + course1score;
        ScoreSound.Play();

        yield return new WaitForSeconds(1);
        SecondText.text =  "Stage2:" + course2score;
        ScoreSound.Play();

        yield return new WaitForSeconds(1);
        ThirdText.text = "Stage3:" + course3score;
        ScoreSound.Play();

        yield return new WaitForSeconds(1);
        FourthText.text = "Stage4:" + course4score;
        ScoreSound.Play();

        yield return new WaitForSeconds(1);
        ResultText.text = "Total:" + (course1score + course2score + course3score + course4score);
        ScoreSound.Play();

        yield return new WaitForSeconds(2);
        ButtonSound.Play();
        tittleButton.SetActive(true);
    }
}
