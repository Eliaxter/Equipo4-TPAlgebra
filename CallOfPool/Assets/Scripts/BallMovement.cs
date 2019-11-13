using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public GameObject ball;
    public Vector2 force;
    private Vector2 posicionMouse;
    private float forceAmount = 0;
    private float minSpeed = 0.0005f;
    private float maxForce = 30.0f;
    private float friction = 1.02f;
    private float aux = 0.0f;
    Vector2 aux2;
    Vector2 aux3;
    float aux4;
    float aux5;

    void Start()
    {
        force.x = 0.0f;
        force.y = 0.0f;
    }

    void Update()
    {
        this.transform.Translate((Vector3)force);
        if (Input.GetMouseButton(0))
        {
            if (forceAmount < maxForce)
            {
                forceAmount += 1.0f;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            posicionMouse = Camera.main.WorldToScreenPoint(ball.transform.position) - Input.mousePosition;

            force = posicionMouse /*- (Vector2)ball.transform.position*/;

            force.x = Mathf.Abs(force.x);
            force.y = Mathf.Abs(force.y);

            aux = force.x + force.y;

            force.x = force.x / aux;
            force.y = force.y / aux;

            force *= forceAmount * Time.deltaTime;
            if (posicionMouse.x < 0)
            {
                force.x *= -1;
            }
            if (posicionMouse.y < 0)
            {
                force.y *= -1;
            }
            forceAmount = 0;
            aux = 0;
        }
        if (force.x != 0.0f)
        {
            force.x /= friction;
        }
        if (force.y != 0.0f)
        {
            force.y /= friction;
        }
        if (Mathf.Abs(force.x) < minSpeed&& Mathf.Abs(force.x)!=0)
        {
            force.x = 0.0f;
            Debug.Log((Vector2)ball.transform.position);
        }
        if (Mathf.Abs(force.y) < minSpeed&& Mathf.Abs(force.y)!=0)
        {
            force.y = 0.0f;
        }
    }

}
