using UnityEngine;
using UnityEngine.InputSystem;



[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{  
  public bool isPaused;

    [Header("Audio")]
    [SerializeField] private AudioSource playerAudio;
    [SerializeField] private AudioClip walkSound;
    [SerializeField] private AudioClip runSound;

    [SerializeField] private AudioClip jumpPlayerSound;

    [SerializeField] private AudioClip jumpSound;
    
    

    [Header("Camera")]
    [SerializeField] private Transform playerCamera;

    private CharacterController playerController;
    
    [Header("Movement")]
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float acceleration = 12f;
    [SerializeField] private float deceleration = 8f;
    [SerializeField] private float crouchSpeed = 2.5f;
    [SerializeField] private float smoothSpeed;
    [SerializeField] private float smoothmovement;

    [Header("Camera Sensitivity")]
    [SerializeField] private float xRotation = 0f;
    public float controllerSensitivity = 0.1f;

    [Header("Physics and Gravity")]
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = -9.81f;
    public Vector3 velocity;
    private bool isGrounded;

    [SerializeField] private float groundCheckDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundCheck;


    [Header("Crounching")]
    [SerializeField] private float crouchHeight = 0.5f;
    [SerializeField] private float standingHeight = 2f; 
    [SerializeField] private LayerMask obstacleLayer;
  
    

    public float currentSpeed;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private bool isRunning;
    private bool isCrouching;
    private bool isJumping;
    public bool isInteracting;



    void Awake()
    {
      playerController = GetComponent<CharacterController>();
    }
    
    void Start()
    { 
      // Cursor.visible = false;
       //Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    { 
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        HandleCrouching();
        HandleMovement();
        HandleLook();

    }

   public void OnMove(InputAction.CallbackContext context)
    {
        if (isPaused)
        {
            
        }
        else
        {
             moveInput = context.ReadValue<Vector2>();
        
            playerAudio.PlayOneShot(walkSound);
        }
       
    
    }
     public void OnLook(InputAction.CallbackContext context)
    {
        if (isPaused)
        {
            
        }
        else
        {
            
            lookInput = context.ReadValue<Vector2>();
        }
    }
    
    public void OnRun(InputAction.CallbackContext context)
    {
        if (isPaused)
        {
            
        }
        else
        {
            if (context.started)
            {
            isRunning = true;
            }
            else if (context.canceled)
            {
            isRunning = false;
            }

            playerAudio.PlayOneShot(runSound);
        }
        
       
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (isPaused)
        {
            
        }
        else
        {
             if (context.started)
            {
            isCrouching = true;
            }
            else if (context.canceled)
            {
           
           
                isCrouching = false;
                
            
            }
        }
       
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (isPaused)
        {
            
        }
        else
        {
             if(context.started && isGrounded && !isJumping)
            {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            playerAudio.PlayOneShot(jumpPlayerSound);
            playerAudio.PlayOneShot(jumpSound);
        }
       
    }

   
    void HandleMovement()
    {
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        playerController.Move(move * currentSpeed * Time.deltaTime);

        if (isJumping && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            isJumping = false;
        }

        velocity.y += gravity * Time.deltaTime;
        playerController.Move(velocity * Time.deltaTime);
    }

    void HandleCrouching()
    {
        if (isCrouching)
        {
            playerController.height = crouchHeight;
            currentSpeed = crouchSpeed;
        }
        else
        {
            playerController.height = standingHeight;
            currentSpeed = isRunning ? runSpeed : walkSpeed;
        }
    }
    void HandleLook()
    {
        xRotation -= lookInput.y * controllerSensitivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * lookInput.x * controllerSensitivity);

    }



    
}

    

