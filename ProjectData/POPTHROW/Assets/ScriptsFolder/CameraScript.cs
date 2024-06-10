using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    public GameObject startCam;
    private Vector3 offset;
    public GameObject[] Chara;
    public bool Panel;
    public int A;
    public Vector3 oldpos;
    public Quaternion oldrote;
    public AudioSource push;
    public PlayerControllScript playerScript;
    public GameObject ShotButton;
    bool IsMouseBTN;
    public float IsMouseTimer;
    float qtaroDistance;
    int playNum;
    public Vector3 touchStartPos;
    public Vector3 touchEndPos;
    public float directionX;
    public Vector3 StaartPos;
    CameraChangeScript cameraChange;
    ClearScript clearScript;
    public bool start;
    CameraMoveScript moveScript;
    public int CamNum = 0;
    public float cameraPosY;
    public float playerPosY;
    Vector3 cameraPos;
    Quaternion cameraRot;
    Quaternion playerRot;
    public float startTime = 0.2f;
    public GameObject arrow;

    public void Awake()
    {
        start = true;
        startCam = GameObject.Find("StartCam");
        Grant();
        FirstPos();
    }

    private void OnEnable()
    {
        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<PlayerControllScript>();
        playerScript.mainCam = this.gameObject;
    }

    void Start()
    {
        A = 0;
        //Release();
        Invoke("Des", 0.1f);
        Invoke("Startpos", 0.2f);
        Invoke("Grant", 0.3f);
        Panel = true;
        cameraChange = GetComponent<CameraChangeScript>();
        clearScript = GameObject.Find("Trash").GetComponent<ClearScript>();
        playerRot = player.transform.rotation;
        cameraRot = transform.rotation;
        startTime = 0.4f;
    }

    void Update()
    {
        CamNum --;
        startTime -= Time.deltaTime;
        if (startTime < 0.0f)
        {
            if (this.gameObject.transform.position.y <= -5)
            {
                player.transform.position = StaartPos;
            }
            if (IsMouseBTN)
            {
                IsMouseTimer += Time.deltaTime;
            }
            if (player != null)
            {
                oldpos = player.transform.position;
                oldrote = player.transform.rotation;
            }

            if (Input.GetMouseButtonDown(0))
            {
                IsMouseBTN = true;
                IsMouseTimer = 0;
                touchStartPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            }
            if (Input.GetMouseButtonUp(0))
            {
                IsMouseBTN = false;
                touchEndPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
                directionX = touchEndPos.x - touchStartPos.x;
                if (IsMouseTimer <= 0.4f && directionX >= 30 && playerScript.shotSwich && CamNum <= 0)
                {
                    if(start == false)
                    {

                        A++;
                        Des();
                        Invoke("Seisei", 0.1f);
                        Invoke("Grant", 0.2f);
                        if (A == 3)
                        {
                            A = 0;
                        }
                        CamNum = 20;
                    }
                    Destroy(startCam);
                    start = false;
                }
                else if (IsMouseTimer <= 0.4f && directionX <= -30 && playerScript.shotSwich && CamNum <= 0)
                {
                    A--;
                    Des();
                    Invoke("Seisei", 0.1f);
                    Invoke("Grant", 0.2f);
                    if (A == -1)
                    {
                        A = 2;
                    }
                }
                else
                {
                    Move();
                }
                CamNum = 20;
            }
            if (playerScript.shotSwich == true)
            {
                arrow.SetActive(true);
                if (SceneManager.GetActiveScene().name == "Course1")
                {
                    if (PlayerControllScript.Score1 >= 11)
                    {
                        SceneManager.LoadScene("Course2");
                    }
                }
                if (SceneManager.GetActiveScene().name == "Course2")
                {
                    if (PlayerControllScript.Score2 >= 11)
                    {
                        SceneManager.LoadScene("Course3");
                    }
                }
                if (SceneManager.GetActiveScene().name == "Course3")
                {
                    if (PlayerControllScript.Score3 >= 11)
                    {
                        SceneManager.LoadScene("Course4");
                    }
                }
                if (SceneManager.GetActiveScene().name == "Course4")
                {
                    if (PlayerControllScript.Score4 >= 11)
                    {
                        SceneManager.LoadScene("End");
                    }
                }
            }
            else
            {
                arrow.SetActive (false);
            }
        }
    }

    public void Move()
    {
        player.GetComponent<PlayerControllScript>().enabled = true;
    }


    public void Grant()
    {
        transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<PlayerControllScript>();
    }

    public void Release()
    {
        gameObject.transform.parent = null;
    }

    public void Des()
    {
        Release();
        GameObject Pl = GameObject.FindWithTag("Player");
        Destroy(Pl);

    }

    public void Seisei()
    {
        Instantiate(Chara[A], oldpos, oldrote);
    }

    public void FirstPos()
    {
        if (SceneManager.GetActiveScene().name == "Course1")
        {
            StaartPos =new Vector3(0, 1.65f, 1);
        }
        if (SceneManager.GetActiveScene().name == "Course2")
        {
            StaartPos = new Vector3(-2.25f, 0.56f, 0.15f);
        }
        if (SceneManager.GetActiveScene().name == "Course3")
        {
            StaartPos = new Vector3(-19, 0.5f, -19.5f);
        }
        if (SceneManager.GetActiveScene().name == "Course4")
        {
            StaartPos = new Vector3(121.5f, 17.8f, 73.8f);
        }
    }

    public void Startpos()
    {
        if(SceneManager.GetActiveScene().name == "Course3")
        {
            Instantiate(Chara[A], StaartPos, Quaternion.Euler(-135,29,0));
        }else if(SceneManager.GetActiveScene().name == "Course4")
        {
            Instantiate(Chara[A], StaartPos, Quaternion.Euler(-135, 0, 0));
        }
        else
        {
            Instantiate(Chara[A], StaartPos, Quaternion.Euler(-45,0,180));
        }
    }


}
