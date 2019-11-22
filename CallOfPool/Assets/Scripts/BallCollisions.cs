using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisions : MonoBehaviour
{
    public BlackBallMovement blackBallMovement;
    public GameObject ball;
    public GameObject blackBall;
    public BallMovement ballMovement;
    public Table table;
    private float distBetweenBalls;
    private Vector2 blackBallToScreenPos;

    public Vector2 newForce;
    private Vector2 newForce2;
    private float oldSpeed;
    private float aux;
    private bool collides=true;


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

        //Debug.Log(Camera.main.WorldToScreenPoint(blackBall.transform.position));
        blackBallToScreenPos = Camera.main.WorldToScreenPoint(blackBall.transform.position);

        if (Vector3.Distance(ball.transform.position, blackBall.transform.position) <= ball.transform.lossyScale.x / 2.0f + blackBall.transform.lossyScale.x / 2.0f /*&& collides ==true*/)
        {
            oldSpeed = Mathf.Abs(ballMovement.force.x) + Mathf.Abs(ballMovement.force.y) + blackBallMovement.blackBallForce.x + blackBallMovement.blackBallForce.y;
            newForce = blackBallToScreenPos - (Vector2)Camera.main.WorldToScreenPoint(ball.transform.position);
            newForce2 = newForce;

            newForce.x = Mathf.Abs(newForce.x);
            newForce.y = Mathf.Abs(newForce.y);

            aux = newForce.x + newForce.y;

            newForce.x = newForce.x / aux;
            newForce.y = newForce.y / aux;

            if (newForce2.x > 0)
            {
                newForce.x *= -1;
            }
            if (newForce2.y > 0)
            {
                newForce.y *= -1;
            }


            
            newForce *= oldSpeed/* * Time.deltaTime*/;
            Debug.Log("oldspeed"+newForce2);
            ballMovement.force = newForce;
            collides = false;
        }

    }
}
