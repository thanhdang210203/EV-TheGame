using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_movement : MonoBehaviour
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
    public bool AbleToJump = false;
    public float turnspeed = 100.0f;
    public float movespeed = 4.0f;
    public bool isJumping;       //a bool to enable hold jumping
    private float JumpCounter;  //after player passed lv1, hold jump will be availabel in lv2,
    public float JumpTime;     //but perspective is kind of 2d so the platform is easier to navigate around.

   
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;

        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime);
            transform.Rotate(Vector3.up * turnspeed * Input.GetAxis("Horizontal") * Time.deltaTime);
            transform.Translate(0f, 0f, movespeed * Input.GetAxis("Vertical") * Time.deltaTime);
            
        }

        

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if(AbleToJump)
        {
            PlayerJump();
        }

        void PlayerJump()
        {
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jump * -2.0f * gravity);
                isJumping = false;
                JumpCounter = JumpTime;

            }
            JumpHigher();
        }
        void JumpHigher()
        {
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
            {
                if (JumpCounter > 0)
                {
                    velocity.y = Mathf.Sqrt(jump * -2.0f * gravity);
                    JumpCounter -= Time.deltaTime;
                }
                else
                {
                    isJumping = false;
                }                
            }
        }    
    }
}
