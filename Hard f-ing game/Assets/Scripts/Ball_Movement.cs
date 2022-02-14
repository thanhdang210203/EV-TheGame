using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Movement : MonoBehaviour
{

    public Transform cam;
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float speed = 5f;
    public float jump = 2f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public float gravity = -9.81f;
    public float groundDistance = 0.2f;
    private Vector3 velocity;
    private bool isGrounded;
    private Rigidbody player;
    public bool TwoD_Cam = false;
    public bool AbleToJump = false;
    public float turnspeed = 100.0f;
    public float movespeed = 4.0f;
    public bool isJumping;       //a bool to enable hold jumping
    private float JumpCounter;  //after player passed lv1, hold jump will be availabel in lv2,
    public float JumpTime;     //but perspective is kind of 2d so the platform is easier to navigate around.


    private void Start()
    {
        player.GetComponent<Rigidbody>();
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        transform.Translate(0f, 0f, movespeed * Input.GetAxis("Horizontal") * Time.deltaTime);

        if (AbleToJump)
        {
            PlayerJump();
        }

        void PlayerJump()
        {
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                player.AddForce(transform.up * jump, ForceMode.Impulse);
                isJumping = false;
                JumpCounter = JumpTime;
                Debug.Log("Jumping");

            }
        //    JumpHigher();
        }
        //void JumpHigher()
        //{
        //    if (Input.GetKey(KeyCode.Space) && isJumping == true)
        //    {
        //        if (JumpCounter > 0)
        //        {
        //            velocity.y = Mathf.Sqrt(jump * -2.0f * gravity);
        //            JumpCounter -= Time.deltaTime;
        //        }
        //        else
        //        {
        //            isJumping = false;
        //        }
        //    }
        //}
    }
}
