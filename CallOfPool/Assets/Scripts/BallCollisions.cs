using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisions : MonoBehaviour
{
    public GameObject ball;
    public GameObject blackBall;
    public BallMovement ballMovement;
    public Table table;
    private float distBetweenBalls;


    void Start()
    {
        blackBall = GameObject.Find("Black-Ball");
    }
    void Update()
    {
        if (ball.transform.position.x >= (table.limitRight - ball.transform.lossyScale.x / 2) && ballMovement.force.x > 0) ballMovement.force.x *= -1;
        if (ball.transform.position.x <= table.limitLeft + ball.transform.lossyScale.x / 2 && ballMovement.force.x < 0) ballMovement.force.x *= -1;
        if (ball.transform.position.y >= table.limitUp - ball.transform.lossyScale.y / 2 && ballMovement.force.y > 0) ballMovement.force.y *= -1;
        if (ball.transform.position.y <= table.limitDown + ball.transform.lossyScale.y / 2 && ballMovement.force.y < 0) ballMovement.force.y *= -1;

        if (Vector3.Distance(ball.transform.position, blackBall.transform.position) <= ball.transform.lossyScale.x / 2.0f + blackBall.transform.lossyScale.x / 2.0f)
        {
            ballMovement.force *= -1.0f;
        }


    }
}
