using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public GameObject ball;
    public Vector2 force;
    public float forceAmount = 0.0f;

    void Start()
    {
        force.x = 0.0f;
        force.y = 0.0f;
    }

    void Update()
    {
        this.transform.position += (Vector3)force;
        if (Input.GetMouseButtonDown(0))
        {
            force.x = 0.2f;
            //force.y = 0.2f;
        }
        if (force.x > 0.0f)
        {
            force.x /= forceAmount;
        }
        if (force.x < 0.0f)
        {
            force.x /= forceAmount;
        }
        if (force.x == 0.0f)
        {
            force.x = 0.0f;
        }
        
    }


}
