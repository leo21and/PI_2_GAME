using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    private PlayerInput playerInput;
    public float speed;
    private Vector2 move;
    public CharacterController cc;
    private Vector3 horizontalMovement;
    private Animator playerAnimator;
    private float currentVelocity;
    
    
    [SerializeField] private float gravity = -30f; 
    [SerializeField] private bool isGrounded = true; 
    [SerializeField] private bool jump = false;
    [SerializeField] private float jumpHeight = 1f;
    private Vector3 verticalVelocity = Vector3.zero;
    [SerializeField] private LayerMask groundMask;

    private Camera camera;

    [SerializeField] private PlayerDamage pDamage;
   // private int flowerCount;

    private void Awake()
    {
        playerInput = new PlayerInput(); 
        playerInput.Player.Jump.performed += OnJumpPressed;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        camera = FindObjectOfType<Camera>();
        //flowerCount = GetComponent<FlowersToxic>().flowerSavedCount;
    }
    
    private void OnEnable()
    {
        playerInput.Player.Enable(); 
    }

    private void OnDisable()
    {
        playerInput.Player.Disable(); 
    }

    public void OnJumpPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (isGrounded)
            {
                jump = true;
                //animation clip
            }
        }
    }
    
    public void Jump()
    {
        if (jump && isGrounded)
        {
            verticalVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
            jump = false;
        }

        verticalVelocity.y += gravity * Time.deltaTime;
        cc.Move(verticalVelocity * Time.deltaTime);
    }
    
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(new Vector3(transform.position.x, gameObject.transform.position.y, transform.position.z), 0.1f);
    }
    
    
    // Update is called once per frame
    void Update()
    {
        //multiply 2 vectors
        currentVelocity = Vector3.Scale(gameObject.transform.forward, horizontalMovement).magnitude;
        
        Move();
        Jump();
    }
    
    
    void Move()
    {
        
        isGrounded = Physics.CheckSphere(new Vector3(transform.position.x, gameObject.transform.position.y, transform.position.z), 0.1f, groundMask);
        if (isGrounded)
        {
            verticalVelocity.y = 0f;

        }
        
        move = playerInput.Player.Move.ReadValue<Vector2>();

        horizontalMovement = (move.y * transform.forward) + (move.x * transform.right);
        
        cc.Move(horizontalMovement * speed * Time.deltaTime); 
      
        playerAnimator.SetFloat("Velocity", currentVelocity);
        
    }
    
    //UnlockAreas

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lock1"))
        {
            Debug.Log("entrou");
            if (pDamage.countF == 1) //&animais&silvas
            {
                Destroy(collision.gameObject);
            }
        }
        else if (collision.gameObject.tag == "Lock2")
        {
           
        }
        else if (collision.gameObject.tag == "Lock3")
        {
            
        }
        else if (collision.gameObject.tag == "Lock4")
        {
            
        }
        
    }
}
