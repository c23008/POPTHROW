using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControllScript : MonoBehaviour
{
    public static float charge;
    public bool down;
    public Rigidbody RG;
    public float grounded;
    public static int Score1 = 1;
    public static int Score2 = 1;
    public static int Score3 = 1;
    public static int Score4 = 1;
    public bool shotSwich;
    public GameObject Button;
    GameObject can;
    public int control;
    public Gyroscope gyroscope;
    Vector3 accel;
    private Vector3 Acceleration;
    private Vector3 preAcceleration;
    float DotProduct;
    public bool Shotbool = false;
    CameraScript cameraSc;
    public AudioSource shakeSE;
    float pitchRange = 0.1f;
    CameraChangeScript changeScript;
    public GameObject mainCam;
    public BoxCollider box;
    public bool playerRot = false;
    int count;
    public float playerRoteZ;
    public float startTime = 0.2f;
    public static bool chergeBool = false;
    public bool shotB = false;
    bool start;

    private void Awake()
    {
        GameObject power = GameObject.Find("Power");
        GameObject score = GameObject.Find("Score");
        RG = GetComponent<Rigidbody>();
        can = GameObject.Find("Canvas");
    }

    void Start()
    {
        control = 10;
        RG.isKinematic = true;
        shotSwich = true;
        Input.gyro.enabled = true;
        mainCam = GameObject.Find("Empty");
        cameraSc = mainCam.GetComponent<CameraScript>();
        down = true;
        changeScript = GetComponent<CameraChangeScript>();
        box = GetComponent<BoxCollider>();
        count = 1;
        startTime = 0.2f;
    }
    void Update()
    {
        startTime -= Time.deltaTime;
        if (startTime < 0)
        {
            if (cameraSc.start == false)
            {
                playerRoteZ = transform.localEulerAngles.z;
                if (Mathf.Approximately(Time.timeScale, 0f)) return;
                control--;
                if (this.gameObject.transform.position.y <= -5)
                {
                    //RG.velocity = Vector3.zero;
                    grounded = 2;
                }

                if (control <= 0)
                {
                    accel = Input.acceleration;//acceleration = Ž¿—Ê‚ð–³Ž‹‚µ‚ÄRigidbody‚ÉŒp‘±“I‚È‰Á‘¬‚ð’Ç‰Á‚·‚é
                    gyroscope = Input.gyro;
                    //transform.rotation = gyroscope.attitude;//attitude = ŒX‚«‚ð•Ô‚·
                    playerRote();
                    control = 0;
                    Shake();
                    Rot();
                    ShakeCheck();
                    if (shotB == false)
                    {
                        tes();
                    }
                    if (chergeBool)
                    {
                        chergeBool = false;
                    }
                    if (charge > 30)
                    {
                        charge = 30;
                    }

                    if (shotSwich == false)
                    {
                        mass();
                    }
                    if (shotSwich == true)
                    {
                        RG.mass = 1;
                    }

                    if (Input.GetButtonDown("Fire2"))
                    {
                        charge++;
                        shakeSE.pitch = 1.0f + Random.Range(-pitchRange, pitchRange);
                        shakeSE.PlayOneShot(shakeSE.clip);
                        chergeBool = true;
                    }

                    if (RG.IsSleeping() || grounded >= 1)
                    {
                        Stop();
                    }
                }
                if (mainCam.activeSelf == false)
                {
                    Time.timeScale = 0f;
                }
            }
        }
    }


    void Shake()
    {
        if (Input.GetButtonDown("Fire1") && shotSwich == true)
        {
            down = false;
            //charge++;
        }
        else
        {
            Invoke("Down", 0.3f);
        }
        if (charge > 0 && down)
        {
            charge = charge - Time.deltaTime;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag != "Wool")
        {
            grounded += Time.deltaTime;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        grounded = 0;
        /*if(grounded > 0)
        {
            count = 0;

        }*/
        
    }

    void Down()
    {
        down = true;
        playerRot = true;
    }

    public void Shot()
    {
        CharaPower();
        charge = 0;
        shotSwich = false;
        count = 0;
    }

    void Rot()
    {
        if (shotSwich == true)
        {
            transform.Rotate(Input.GetAxis("Vertical"), 0f, Input.GetAxis("Horizontal"));
        }
    }

    public void Stop()
    {
        RG.isKinematic = true;
        shotSwich = true;
        box.isTrigger = true;
        if (count == 0)
        {
            transform.localRotation = Quaternion.Euler(-90, transform.localEulerAngles.y, playerRoteZ );
            count = 1;
        }
        shotB = false;
    }

    void mass()
    {
        RG.mass -= Time.deltaTime / 4;
        if (RG.mass < 0.5f)
        {
            RG.mass = 0.5f;
        }
    }

    public void CharaPower()
    {
        if(this.gameObject.name == "PM1(Clone)")
        {
            RG.AddForce(-(transform.up) * charge * 70);
        }
        else if(this.gameObject.name == "PlayerModel2(Clone)")
        {
            RG.AddForce(-(transform.up) * charge * 55);
        }
        else if(this.gameObject.name == "PM2(Clone)")
        {
            RG.AddForce(-(transform.up) * charge * 40);
        }
    }

    public void Course()
    {
        if(SceneManager.GetActiveScene().name == "Course1")
        {
            Score1++;
            if(Score1 >= 11)
            {
                Score1 = 11;
            }
        }
        if (SceneManager.GetActiveScene().name == "Course2")
        {
            Score2++;
            if (Score2 >= 11)
            {
                Score2 = 11;
            }
        }
        if (SceneManager.GetActiveScene().name == "Course3")
        {
            Score3++;
            if (Score3 >= 11)
            {
                Score3 = 11;
            }
        }
        if (SceneManager.GetActiveScene().name == "Course4")
        {
            Score4++;
            if(Score4 >= 11)
            {
                Score4 = 11;
            }
        }
    }

    public void tes()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if(cameraSc.directionX < 0.7 && cameraSc.directionX > -0.7f || changeScript.directionY < 30 && changeScript.directionY > -30)
            {
                RG.isKinematic = false;
                Shot();
                Course();
                Shotbool = true;
                box.isTrigger = false;
                shotB = true;
            }
        }
    }

    public void ShakeCheck()
    {
        preAcceleration = Acceleration;
        Acceleration = Input.acceleration;
        DotProduct = Vector3.Dot(Acceleration, preAcceleration);
        if (DotProduct >= 1.1f)
        {
            charge++;
            chergeBool = true;
        }
        shakeSE.pitch = 1.0f + Random.Range(-pitchRange, pitchRange);
        shakeSE.Play();
    }

    public void playerRote()
    {
        float pitch = -Input.gyro.rotationRate.x * Mathf.Rad2Deg;
        float yaw = Input.gyro.rotationRate.z * Mathf.Rad2Deg;
        float roll = -Input.gyro.rotationRate.y * Mathf.Rad2Deg;
        transform.Rotate(new Vector3(pitch / 10, 0, roll / 10));
    }

}
