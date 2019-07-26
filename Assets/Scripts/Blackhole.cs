using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackhole : MonoBehaviour
{
    Ball mainBall;
    [SerializeField] Blackhole blackhole;

    private void Start()
    {
        mainBall = FindObjectOfType<Ball>();               
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        WarpBall();        
    }

    private void WarpBall()
    {
        Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0f, mainBall.randomFactor), UnityEngine.Random.Range(0f, mainBall.randomFactor));
        
        Vector2 blackholePos = new Vector2(blackhole.transform.position.x, blackhole.transform.position.y);
        mainBall.transform.position = blackholePos;
        mainBall.GetComponent<Rigidbody2D>().velocity += velocityTweak;
        DeactivateBlackhole();

        Invoke("ActivateBlackhole", 0.25f);
    }
    private void DeactivateBlackhole() {
        blackhole.gameObject.SetActive(false);
    }
    private void ActivateBlackhole() {
        blackhole.gameObject.SetActive(true);
    }
}
