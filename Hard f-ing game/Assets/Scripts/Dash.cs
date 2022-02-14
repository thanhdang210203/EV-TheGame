using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float dashSpeed;
    public float dashTime;
    Cube_movement moveScript;
    // Start is called before the first frame update
    void Start()
    {
        moveScript = GetComponent<Cube_movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Dashhh());

            Debug.Log("fffffff");
        }
    }

    IEnumerator Dashhh()
    {
        float startTime = Time.time;

        while(Time.time < startTime + dashTime)
        {
            moveScript.controller.Move(moveScript.moveDir * dashSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
