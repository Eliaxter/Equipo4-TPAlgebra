using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisions : MonoBehaviour
{
    public GameObject Ball;
    public GameObject BlackBall;
    public BallMovement ballMovement;
    public Table table;
    private Vector2 relativeBallPos;

    void Start()
    {
        BlackBall = GameObject.Find("Black-Ball");
    }
    void Update()
    {
        if (Ball.transform.position.x >= (table.limitRight - Ball.transform.lossyScale.x / 2) && ballMovement.force.x > 0) ballMovement.force.x *= -1;
        if (Ball.transform.position.x <= table.limitLeft + Ball.transform.lossyScale.x / 2 && ballMovement.force.x < 0) ballMovement.force.x *= -1;
        if (Ball.transform.position.y >= table.limitUp - Ball.transform.lossyScale.y / 2 && ballMovement.force.y > 0) ballMovement.force.y *= -1;
        if (Ball.transform.position.y <= table.limitDown + Ball.transform.lossyScale.y / 2 && ballMovement.force.y < 0) ballMovement.force.y *= -1;

        if (Mathf.Abs (BallPosVector(Ball) - BallPosVector(BlackBall)) < Ball.transform.lossyScale.x)
        {
            ballMovement.force.x *= -1;
        }
    }
    float BallPosVector(GameObject ball)
    {
        relativeBallPos = Camera.main.WorldToScreenPoint(ball.transform.position);
        return relativeBallPos.x + relativeBallPos.y;
    }
}
