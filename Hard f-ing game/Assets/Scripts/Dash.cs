using System.Collections;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float dashSpeed;
    public float dashTime;
    private Cube_movement moveScript;

    // Start is called before the first frame update
    private void Start()
    {
        moveScript = GetComponent<Cube_movement>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Dashhh());

            Debug.Log("fffffff");
        }
    }

    private IEnumerator Dashhh()
    {
        float startTime = Time.time;

        while (Time.time < startTime + dashTime)
        {
            moveScript.controller.Move(moveScript.moveDir * dashSpeed * Time.deltaTime);

            yield return null;
        }
    }
}