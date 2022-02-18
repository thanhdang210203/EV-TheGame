using System.Collections;
using UnityEngine;

public class Cube_movement : MonoBehaviour
{
    public Transform cam;
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float speed = 5.0f;
    public float jump = 2.0f;
    public float dash = 4.0f;
    private float dash_revers = -4.0f; //I was going to use just one key(E) for both direction dashing but I was not quite familiar with using velocity and mathf values
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    public float gravity = -9.81f;
    public float groundDistance = 0.2f;
    private Vector3 velocity;
    public Vector3 moveDir;
    private bool isGrounded;
    public bool Dashable = false;
    private bool isDashing;
    private float Dash_Counter;
    private float Current_Dash_Timer;
    public bool Able_To_Dash;
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
    public AudioClip Jump_Sound;
    public float bounce_force;
    private float drag_force = -5.5f;
    private float drag_force_revres = 5.5f;
    private float DashDirection;
    public float bump_force = -0.3f;

    private void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0 && velocity.z < 0)
        {
            velocity.y = -1f;
            velocity.z = 0f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (Thrid_cam)
        {
            if (direction.magnitude >= 0.1f)
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
                //player.AddForce(transform.up * jump, ForceMode.Impulse);
                velocity.y = Mathf.Sqrt(jump * -3.0f * gravity);
                AudioSource.PlayClipAtPoint(Jump_Sound, new Vector3(0, 0, 0));
                StartCoroutine(Jump_Lag());
                isJumping = false;
                JumpCounter = JumpTime;
                Debug.Log("Jumping");
            }
        }

        //Dash mechanic
        if (Input.GetKeyDown(KeyCode.E) && Dashable == true && Able_To_Dash == true && horizontal != 0 && !isGrounded)
        {
            isDashing = true;
            Current_Dash_Timer = Dash_Counter;
            if (isDashing == true)
            {
                StartCoroutine(DashD());
                StartCoroutine(Latecall_Dash());
            }

            Debug.Log("dashhhhhhhhh");
        }

        if (Input.GetKeyDown(KeyCode.Q) && Dashable == true && Able_To_Dash == true && horizontal != 0 && !isGrounded)
        {
            StartCoroutine(DashA());
            StartCoroutine(Latecall_Dash());
        }

        if (isDashing)
        {
            Current_Dash_Timer -= Time.deltaTime;
            if (Current_Dash_Timer <= 0)
            {
                isDashing = false;
            }
        }

        IEnumerator Latecall_Dash()
        {
            Dashable = false;
            yield return new WaitForSeconds(Dashing_Sound.length);
            velocity.z = 0f;
            Dashable = true;
        }

        IEnumerator DashA()
        {
            AudioSource.PlayClipAtPoint(Dashing_Sound, new Vector3(0, 0, 0));
            velocity.z = Mathf.Sqrt(-2.0f * drag_force) * dash_revers;
            //player.AddForce(transform.forward * dash, ForceMode.Force);
            if (velocity.z < 0)
            {
                DashDirection = horizontal;
                velocity.z -= drag_force_revres * Time.deltaTime;
            }
            else if (velocity.z > 0)
            {
                velocity.z = 0f;
                Dashable = true;
            }

            yield return null;
        }
        IEnumerator DashD()
        {
            AudioSource.PlayClipAtPoint(Dashing_Sound, new Vector3(0, 0, 0));
            velocity.z = Mathf.Sqrt(-2.0f * drag_force) * dash;
            //player.AddForce(transform.forward * dash, ForceMode.Force);
            if (velocity.z > 0)
            {
                DashDirection = horizontal;
                velocity.z += drag_force * Time.deltaTime;
            }
            else if (velocity.z < 0)
            {
                velocity.z = 0f;
                Dashable = true;
            }

            yield return null;
        }

        IEnumerator Jump_Lag()
        {
            AbleToJump = false;
            yield return new WaitForSeconds(Jump_Sound.length);
            AbleToJump = true;
        }
    }

    private void OnCollisionEnter(Collision ObjectCollidedWith)
    {
        if (ObjectCollidedWith.collider.tag == "Upper Ceilling")
        {
            Debug.Log("ddddd");
            velocity.y = Mathf.Sqrt(2.0f * gravity) * bump_force;
        }
    }

    //JumpHigher();
    //void JumpHigher()
    //{
    //if (Input.GetKey(KeyCode.Space) && isJumping == true)
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