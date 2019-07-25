using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackhole : MonoBehaviour
{
    Ball mainBall;
    [SerializeField] Blackhole destinationBlackhole;

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
        
        Ball newBall = Instantiate(mainBall, destinationBlackhole.transform.position, destinationBlackhole.transform.rotation);        
        newBall.GetComponent<Rigidbody2D>().velocity += velocityTweak;
        destinationBlackhole.gameObject.SetActive(false);

        Destroy(mainBall);
        //Destroy(GameObject.FindObjectOfType<Ball>());
        //destinationBlackhole.gameObject.SetActive(true);
    }
}
