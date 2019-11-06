using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{

    public GameObject[] walls;
    public float limitRight;
    public float limitLeft;
    public float limitDown;
    public float limitUp;
    void Start()
    {
        limitRight = walls[0].transform.position.x - walls[0].transform.lossyScale.x / 2;
        limitLeft = walls[1].transform.position.x + walls[1].transform.lossyScale.x / 2;
       limitUp = walls[2].transform.position.y - walls[2].transform.lossyScale.y / 2;
       limitDown = walls[3].transform.position.y + walls[3].transform.lossyScale.y / 2;
    }

    void Update()
    {
        
    }
}
