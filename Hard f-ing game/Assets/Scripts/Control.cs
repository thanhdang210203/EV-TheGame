using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control: MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck; 
    public Transform cam;
    private Vector3 playerVelocity;
    public Vector3 moveDir;
    public LayerMask groundMask;
    private bool isGrounded; 
    public float groundDistance = 0.2f;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravity = -9.81f;
    public float turnSmoothTime = 0.1f;
    public float turnspeed = 100.0f;
    float turnSmoothVelocity;
    public bool Thrid_cam = true;
    public bool TwoD_Cam = false;
    public AudioClip Dashing_Sound;
    public float bounce_force;
    private float drag_force = -5.5f;
    float DashDirection;
    public float bump_force = 0.3f;
    public bool Dashable = false;
    private bool isDashing;
    private float Dash_Counter;
    private float Current_Dash_Timer;
    public bool Able_To_Dash;
    public float dash = 4.0f;


    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (Thrid_cam)
        {
            if (move.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
                moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir * playerSpeed * Time.deltaTime);
                transform.Rotate(Vector3.up * turnspeed * Input.GetAxis("Horizontal") * Time.deltaTime);
                transform.Translate(0f, 0f, playerSpeed * Input.GetAxis("Vertical") * Time.deltaTime);

            }

        }
        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (TwoD_Cam)
        {
            transform.Translate(0f, 0f, playerSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
        }

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }

        if (Input.GetKeyDown(KeyCode.E) && Dashable == true && Able_To_Dash == true && horizontal != 0 && !isGrounded)
        {
            isDashing = true;
            Current_Dash_Timer = Dash_Counter;
            if (isDashing == true)
            {
                StartCoroutine(Dashhhh());
                StartCoroutine(Latecall_Dash());
            }

            Debug.Log("dashhhhhhhhh");
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
            playerVelocity.z = 0f;
            Dashable = true;
        }

        IEnumerator Dashhhh()
        {
            AudioSource.PlayClipAtPoint(Dashing_Sound, new Vector3(0, 0, 0));
            playerVelocity.z = Mathf.Sqrt(dash * -2.0f * drag_force);
            //player.AddForce(transform.forward * dash, ForceMode.Force);
            if (playerVelocity.z > 0)
            {
                playerVelocity.z += drag_force * Time.deltaTime;
            }
            else if (playerVelocity.z < 0)
            {
                playerVelocity.z = 0f;
                Dashable = true;
            }

            yield return null;
        }
    }

    void OnCollisionEnter(Collision ObjectCollidedWith)
    {
        if (ObjectCollidedWith.collider.tag == "Upper Ceilling")
        {
            Debug.Log("ddddd");
            playerVelocity.y = Mathf.Sqrt(bump_force * 2.0f * gravity);
        }

    }

}
