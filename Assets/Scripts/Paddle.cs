using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float sceneWidthInUnit = 16f;
    [SerializeField] float maxX = 14.5F;
    [SerializeField] float minX = 1.4F;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
        float mousePosInUnit = Input.mousePosition.x / Screen.width * sceneWidthInUnit;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosInUnit, minX, maxX);
        transform.position = paddlePos;
    }
}
