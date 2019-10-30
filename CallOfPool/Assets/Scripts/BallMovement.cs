using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public GameObject ball;
    public Vector2 force;
    public float forceAmount;

    float aux = 0.0f;
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
        if (Input.GetMouseButtonDown(0))
        {
           
            Vector2 posicionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             force = posicionMouse - (Vector2)ball.transform.position;
            force *= forceAmount * Time.deltaTime;
            force *= -1;



            #region fuego
           // Debug.Log(ball.transform.position);

            //aux2 = ball.transform.position - posicionMouse;
            //aux = aux2.x + aux2.y;
            //
            //Debug.Log(/*aux4 = */aux2.x / -aux);
            //Debug.Log( /*aux5 = */aux2.y / aux);
            //aux4 = aux2.x / aux;
            //aux5 = aux2.y / aux;
            //

            //aux4 = Mathf.Abs(aux4);
            //aux5 = Mathf.Abs(aux5);
            //
            //Debug.Log( /*force.x = */forceAmount * aux4);
            //Debug.Log(/*force.y = */forceAmount * aux5);
            //if (posicionMouse.x < 0) aux4 *= 1;
            //if (posicionMouse.x > 0) aux4 *= -1;
            //if (posicionMouse.y < 0) aux5 *= -1;
            //if (posicionMouse.x > 0) aux5 *= 1;
            //
            //force.x = forceAmount * aux4;
            //force.y = forceAmount * aux5;

            //force.x = 0.2f;
            //force.y = 0.2f;
            #endregion
        }
        /*if (force.x > 0.0f)
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
        }*/
        
    }


}
