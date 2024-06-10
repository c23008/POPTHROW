using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class PlayerSC : MonoBehaviour
{
    public AudioSource AS;
    protected AudioSource source;
    [SerializeField] float pitchRange = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        AS.pitch = 1.0f + Random.Range(-pitchRange, pitchRange);
        AS.Play();
    }
}
