using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisions : MonoBehaviour
{
    public GameObject Ball;
    public BallMovement ballMovement;
    void Start()
    {
    }
    void Update()
    {
        if (Ball.transform.position.x >= 5.75f) ballMovement.force.x *= -1;
           
    }
}
