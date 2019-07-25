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
    [SerializeField] public float randomFactor = 0.2f;

    //State
    bool hasStarted = false;
    Vector2 paddleToBall;

    //Cache
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;
    
    // Start is called before the first frame update
    void Start()
    {
        paddleToBall = transform.position - paddleOne.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
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
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
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
        Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0f, randomFactor), UnityEngine.Random.Range(0f, randomFactor));
        if (hasStarted) {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);

            myRigidBody2D.velocity += velocityTweak;
        }
    }
}
