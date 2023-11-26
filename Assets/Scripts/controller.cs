using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class controller : MonoBehaviour
{
    [SerializeField] private Animator jumpAnimation = null;
    public SphereCollider col;
    public float Ballspeed = 300f;
    public ParticleSystem particle;
    public Transform target;
    public Transform particlejump;
    public AudioClip jumpSoundClip;
    public AudioClip jumpSound_DoubleJumpClip;
    public AudioClip StompClip;
    public AudioClip ReturnToGroundClip;
    private Rigidbody rb;
    private float speed2 = 70f;
    private float h;
    private float v;
    private bool PlayerIsGrounded = true;
    private bool DoubleJump = true;
    public Transform LookTarget;
    //public PlayerInput playerInput;
    public InputAction movementAction;
    public InputAction jumpAction;
    public InputAction stompAction;
    public InputAction digAction;
    private bool HasJumped = false;
    private bool canDig;

    private void Awake()
    {
        movementAction.performed += ctx => { OnMove(ctx); };
        jumpAction.performed += ctx => {OnJump(ctx); };
        stompAction.performed += ctx => {OnStomp(ctx); };
        digAction.performed += ctx => {OnDig(ctx); };

    }
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        movementAction.Enable();
        jumpAction.Enable();
        stompAction.Enable();
    }

    private void OnDisable()
    {
        movementAction.Disable();
        jumpAction.Disable();
        stompAction.Disable();
    }


    private void Update()
    {
        Debug.Log(PlayerIsGrounded);
        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && PlayerIsGrounded || Input.GetButton("Jump") && PlayerIsGrounded)
        {
            HasJumped = true;
            DoubleJump = true;
            PlayerIsGrounded = false;
            rb.AddForce(new Vector3(0, 7, 0), ForceMode.Impulse);
            jumpAnimation.Play("jump", 0, 0.0f);
            particlejump.position = target.position;
            particle.Play();
            AudioManager.Instance.PlaySound(jumpSoundClip);
            Debug.Log("Jump");
        }
        // DoubleJumps
        else if (Input.GetKeyDown(KeyCode.Space) && PlayerIsGrounded == false && DoubleJump)
        {
            DoubleJump = false;
            PlayerIsGrounded = false;
            rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
            jumpAnimation.Play("jump", 0, 0.0f);
            particlejump.position = target.position;
            particle.Play();
            AudioManager.Instance.PlaySound(jumpSound_DoubleJumpClip);
            Debug.Log("Double Jump");
        }

        // KeyBoard Controls
        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.AddForce(Vector3.right * Ballspeed * Time.deltaTime);
            Debug.Log("New RIGHT");
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rb.AddForce(-Vector3.right * Ballspeed * Time.deltaTime);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            rb.AddForce(Vector3.forward * Ballspeed * Time.deltaTime);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            rb.AddForce(-Vector3.forward * Ballspeed * Time.deltaTime);
        }

        //Accelerometer Controls//
        h = Input.acceleration.x;
        v = Input.acceleration.y;
        rb.AddForce(new Vector3(h, 0.0f, v) * speed2 * Time.deltaTime, ForceMode.Impulse);
    }

    public void OnJump(InputAction.CallbackContext contex)
    {
        /// Jump
        if (PlayerIsGrounded)
        {
            HasJumped = true;
            DoubleJump = true;
            PlayerIsGrounded = false;
            rb.AddForce(new Vector3(0, 7, 0), ForceMode.Impulse);
            jumpAnimation.Play("jump", 0, 0.0f);
            particlejump.position = target.position;
            particle.Play();
            AudioManager.Instance.PlaySound(jumpSoundClip);
            Debug.Log("Jump");
        }
        // DoubleJumps
        else if (PlayerIsGrounded == false && DoubleJump)
        {
            DoubleJump = false;
            PlayerIsGrounded = false;
            rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
            jumpAnimation.Play("jump", 0, 0.0f);
            particlejump.position = target.position;
            particle.Play();
            AudioManager.Instance.PlaySound(jumpSound_DoubleJumpClip);
            Debug.Log("Double Jump");
        }
    }

    // Movement
    public void OnMove(InputAction.CallbackContext contex)
    {
        
    }

    // Stomp
    public void OnStomp(InputAction.CallbackContext contex)
    {
        if (PlayerIsGrounded == false)
        {
            DoubleJump = false;
            rb.AddForce(new Vector3(0, -7, 0), ForceMode.Impulse);
            particlejump.position = target.position;
            particle.Play();
            AudioManager.Instance.PlaySound(StompClip);
            Debug.Log("Stomp");
            transform.LookAt(LookTarget);
        }
    }

    public void OnDig(InputAction.CallbackContext contex)
    {
        if (canDig == true)
        {

        }
    }


    // Ground Check for Jumping
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            PlayerIsGrounded = true;
            if (HasJumped == true)
            {
                HasJumped = false;
                AudioManager.Instance.PlaySound(ReturnToGroundClip);
                particlejump.position = target.position;
                particle.Play();
            }
        }
    }
}
