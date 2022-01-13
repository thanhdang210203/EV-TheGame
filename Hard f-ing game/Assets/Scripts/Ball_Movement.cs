using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Movement : MonoBehaviour
{
    float turnspeed = 100.0f;
    float movespeed = 4.0f;
    void Update()
    {
        transform.Rotate(Vector3.up * turnspeed * Input.GetAxis("Horizontal") * Time.deltaTime);
        transform.Translate(0f, 0f, movespeed * Input.GetAxis("Vertical") * Time.deltaTime);
       
    }
}
