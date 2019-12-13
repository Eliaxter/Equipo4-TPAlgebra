using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBallMovement : MonoBehaviour
{
    public BallCollisions ballCollisions;
    public GameObject[] ball;
    public Vector2[] force;
    //private GameObject blackBall;
    private GameObject whiteBall;
    public Table table;
    public BallMovement ballMovement;
    public Vector2 blackBallForce;
     
    private float aux;

    void Start()
    {
        //blackBall = this.gameObject;
        whiteBall = GameObject.Find("White-Ball");
        blackBallForce.x = 0.0f;
        blackBallForce.y = 0.0f;
        ball[0] = GameObject.Find("Black-Ball");
        ball[1] = GameObject.Find("Blue-Ball");
        ball[2] = GameObject.Find("Red-Ball");
        ball[3] = GameObject.Find("Yellow-Ball");
        ball[4] = GameObject.Find("Orange-Ball");
        ball[5] = GameObject.Find("Green-Ball");
        for (int i = 0; i < 6; i++)
        {
            force[i] = new Vector2(0.0f, 0.0f);
        }
    }

    void Update()
    {
        for (int i = 0; i < 6; i++)
        {

            ball[i].transform.Translate(force[i]);

            if (Vector3.Distance(whiteBall.transform.position, ball[i].transform.position) <= whiteBall.transform.lossyScale.x / 2.0f + ball[i].transform.lossyScale.x / 2.0f)
            {
                force[i] = ballMovement.lastFrameForce - ballMovement.force;
                if (ballMovement.lastFrameForce.x != 0 || ballMovement.lastFrameForce.x != 0) force[i] /= (force[i] / ballMovement.lastFrameForce);
            }

            if (ball[i].transform.position.x >= (table.limitRight - ball[i].transform.lossyScale.x / 2) && force[i].x > 0) force[i].x *= -1;
            if (ball[i].transform.position.x <= table.limitLeft + ball[i].transform.lossyScale.x / 2 && force[i].x < 0) force[i].x *= -1;
            if (ball[i].transform.position.y >= table.limitUp - ball[i].transform.lossyScale.y / 2 && force[i].y > 0) force[i].y *= -1;
            if (ball[i].transform.position.y <= table.limitDown + ball[i].transform.lossyScale.y / 2 && force[i].y < 0) force[i].y *= -1;

            if (force[i].x != 0.0f)
            {        
                force[i].x /= ballMovement.friction;
            }        
            if (force[i].y != 0.0f)
            {        
                force[i].y /= ballMovement.friction;
            }
            if (Mathf.Abs(force[i].x) < ballMovement.minSpeed && Mathf.Abs(force[i].x) != 0)
            {
                force[i].x = 0.0f;
            }
            if (Mathf.Abs(force[i].y) < ballMovement.minSpeed && Mathf.Abs(force[i].y) != 0)
            {
                force[i].y = 0.0f;
            }

        }
    }
}
