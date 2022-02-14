using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class Cube_movement : MonoBehaviour
{

    public Transform cam;
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float speed = 5f;
    public float jump = 2f;
    public float dash = 4f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public float gravity = -9.81f;
    public float groundDistance = 0.2f;
    private Vector3 velocity;
    public Vector3 moveDir;
    private bool isGrounded;
    public bool Dashable = false;
    private bool Able_To_Dash = true;
    private bool Dash_Time;
    public Rigidbody player;
    public bool AbleToJump = false;
    public float turnspeed = 100.0f;
    public float movespeed = 4.0f;
    public bool isJumping;       //a bool to enable hold jumping
    private float JumpCounter;  //after player passed lv1, hold jump will be availabel in lv2,
    public float JumpTime;     //but perspective is kind of 2d so the platform is easier to navigate around.
    public bool Thrid_cam = true;
    public bool TwoD_Cam = false;
    public AudioClip Dashing_Sound;
    public float bounce_force;
    private float drag_force = 0.5f;


    private void Start()
    {
        player = GetComponent<Rigidbody>();
    }
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

        if (Thrid_cam)
        {
            if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime);
            transform.Rotate(Vector3.up * turnspeed * Input.GetAxis("Horizontal") * Time.deltaTime);
            transform.Translate(0f, 0f, movespeed * Input.GetAxis("Vertical") * Time.deltaTime);
            
        }

        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (TwoD_Cam)
        {
            transform.Translate(0f, 0f, movespeed * Input.GetAxis("Horizontal") * Time.deltaTime);
        }

        

        if (AbleToJump)
        {
            PlayerJump();
        }

        void PlayerJump()
        {
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                //player.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
                velocity.y = Mathf.Sqrt(jump * -2.0f * gravity);
                isJumping = false;
                JumpCounter = JumpTime;
                Debug.Log("Jumping");

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




        //Dash mechanic
        if (Input.GetKeyDown(KeyCode.E) && Dashable == true && Able_To_Dash == true)
        {
            StartCoroutine(Dashhhh());
            StartCoroutine(Latecall_Dash());
            Debug.Log("dashhhhhhhhh");
        }

        IEnumerator Latecall_Dash()
        {
            Able_To_Dash = false;
            yield return new WaitForSeconds(Dashing_Sound.length);
            Able_To_Dash = true;
        }

        IEnumerator Dashhhh()
        {
            AudioSource.PlayClipAtPoint(Dashing_Sound, new Vector3(0, 0, 0));
            velocity.z = Mathf.Sqrt(dash * -2.0f * gravity);
            if (velocity.z > 0)
            {
                velocity.z = drag_force * Time.deltaTime;
            }

            yield return null;
        }
    }


}
