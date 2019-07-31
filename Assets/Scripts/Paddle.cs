using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float sceneWidthInUnit = 16f;
    [SerializeField] float maxX = 14.5F;
    [SerializeField] float minX = 1.4F;
    GameStatus gameStatus;
    Ball ball;


    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {                
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }

    public float GetXPos()
    {        
        if (gameStatus.GetStatusAutoPlay())
        {            
            return ball.transform.position.x;
        }
        else {
            float mousePosInUnit = Input.mousePosition.x / Screen.width * sceneWidthInUnit;
            return mousePosInUnit;
        }
    }
}
