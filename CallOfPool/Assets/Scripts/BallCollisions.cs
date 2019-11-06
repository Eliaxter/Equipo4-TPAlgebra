using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisions : MonoBehaviour
{
    public GameObject Ball;
    public BallMovement ballMovement;
    public Table table;
    void Start()
    {

    }
    void Update()
    {
        if (Ball.transform.position.x >= (table.limitRight - Ball.transform.lossyScale.x / 2) && ballMovement.force.x > 0) ballMovement.force.x *= -1;
        if (Ball.transform.position.x <= table.limitLeft + Ball.transform.lossyScale.x / 2 && ballMovement.force.x < 0) ballMovement.force.x *= -1;
        if (Ball.transform.position.y >= table.limitUp - Ball.transform.lossyScale.y / 2 && ballMovement.force.y > 0) ballMovement.force.y *= -1;
        if (Ball.transform.position.y <= table.limitDown + Ball.transform.lossyScale.y / 2 && ballMovement.force.y < 0) ballMovement.force.y *= -1;
    }
}
