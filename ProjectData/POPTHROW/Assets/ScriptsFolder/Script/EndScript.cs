using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class EndScript : MonoBehaviour
{
    public AudioSource AS;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGoTitleButton()
    {
        Invoke("OnGoTitle", 1);
        AS.Play();
    }

    void OnGoTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
