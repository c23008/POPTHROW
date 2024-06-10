using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Clear")
        {
            Debug.Log("Score3\n" + PlayerControllScript.Score3);
            Debug.Log("Score2\n" + PlayerControllScript.Score2);
            Debug.Log("Score1\n" + PlayerControllScript.Score1);
            Debug.Log("çáåv" + (PlayerControllScript.Score1 + PlayerControllScript.Score2 + PlayerControllScript.Score3));
        }   
    }

    void Update()
    {
       
    }
}
