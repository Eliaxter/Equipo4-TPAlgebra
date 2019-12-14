using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBallMovement : MonoBehaviour
{
    public BallCollisions ballCollisions;
    public GameObject[] ball;
    public Vector2[] force;
    private GameObject whiteBall;
    public Table table;
    public BallMovement ballMovement;
     
    private float aux;

    void Start()
    {
        whiteBall = GameObject.Find("White-Ball");
    }

    void Update()
    {
        for (int i = 0; i < 6; i++)
        {
            if (ball[i])
            {
                ball[i].transform.Translate(force[i]);

                if (Vector3.Distance(whiteBall.transform.position, ball[i].transform.position) <= whiteBall.transform.lossyScale.x / 2.0f + ball[i].transform.lossyScale.x / 2.0f)
                {
                    force[i] = ballMovement.beforeLastFrame - ballMovement.force;
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
}
