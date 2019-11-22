using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBallMovement : MonoBehaviour
{
    private GameObject blackBall;
    private GameObject ball;
    private BallCollisions force;

    void Start()
    {
        blackBall = GameObject.Find("Black-ball");
        ball = GameObject.Find("ball");
    }

    void Update()
    {
        //if (Vector3.Distance(ball.transform.position, blackBall.transform.position) <= ball.transform.lossyScale.x / 2.0f + blackBall.transform.lossyScale.x / 2.0f /*&& collides ==true*/)
        //{
            
        //}
    }
}
