using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisions : MonoBehaviour
{

    public  GameObject[] ball;
    public Vector2[] PosOnScreen;
    public GameObject[] hole;
    public Vector2[] PosOnScreenHole;

    public BlackBallMovement blackBallMovement;
    public GameObject whiteBall;
    public BallMovement ballMovement;
    public Table table;
    private float distBetweenBalls;

    public Vector2 newForce;
    private Vector2 newForce2;
    private float oldSpeed;
    private float aux;


    void Start()
    {


    }
    void Update()
    {
        if (whiteBall.transform.position.x >= (table.limitRight - whiteBall.transform.lossyScale.x / 2) && ballMovement.force.x > 0) ballMovement.force.x *= -1;
        if (whiteBall.transform.position.x <= table.limitLeft + whiteBall.transform.lossyScale.x / 2 && ballMovement.force.x < 0) ballMovement.force.x *= -1;
        if (whiteBall.transform.position.y >= table.limitUp - whiteBall.transform.lossyScale.y / 2 && ballMovement.force.y > 0) ballMovement.force.y *= -1;
        if (whiteBall.transform.position.y <= table.limitDown + whiteBall.transform.lossyScale.y / 2 && ballMovement.force.y < 0) ballMovement.force.y *= -1;

        for (int i = 0; i < 6; i++)
        {
            if (ball[i])
            {
                PosOnScreen[i] = Camera.main.WorldToScreenPoint(ball[i].transform.position);
            }
            PosOnScreenHole[i] = Camera.main.WorldToScreenPoint(hole[i].transform.position);
        }

        for (int i = 0; i < 6; i++)
        {
            if (ball[i]!=null)
            {
                if (Vector3.Distance(whiteBall.transform.position, ball[i].transform.position) <= whiteBall.transform.lossyScale.x / 2.0f + ball[i].transform.lossyScale.x / 2.0f)
                {
                    oldSpeed = Mathf.Abs(ballMovement.force.x) + Mathf.Abs(ballMovement.force.y);
                    newForce = PosOnScreen[i] - (Vector2)Camera.main.WorldToScreenPoint(whiteBall.transform.position);
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


                    newForce *= oldSpeed;
                    ballMovement.force = newForce;
                }
               
                for (int j = 0; j < 6; j++)
                {
                    if (Vector3.Distance(ball[i].transform.position, hole[j].transform.position) <= ball[i].transform.lossyScale.x / 2.0f + hole[j].transform.lossyScale.x / 2.0f)
                    {
                        Destroy(ball[i]);
                    }
                }
            }
            if (Vector3.Distance(whiteBall.transform.position, hole[i].transform.position) <= whiteBall.transform.lossyScale.x / 2.0f + hole[i].transform.lossyScale.x / 2.0f)
            {
                whiteBall.transform.position = new Vector2(-3, 0);
                ballMovement.force.x = 0;
                ballMovement.force.y = 0;
            }
        }
    }
}
