using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //Param
    [SerializeField] Paddle paddleOne;
    [SerializeField] float xPush = 0;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;

    //State
    bool hasStarted = false;
    Vector2 paddleToBall;

    //Cache
    AudioSource myAudioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        paddleToBall = transform.position - paddleOne.transform.position;
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted) {            
            LockToPaddle();
            LaunchOnMouseClick();       
        }        
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0)) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);            
            hasStarted = true;            
        }        
    }

    private void LockToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddleOne.transform.position.x, paddleOne.transform.position.y);
        transform.position = paddleToBall + paddlePos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted) {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }        
    }
}
