using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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
    [SerializeField] private Collisions cas;

    [SerializeField] private GameObject text;

    [SerializeField] private Spell spellToCast; //Ser
    [SerializeField] private float maxPower = 100f;
    [SerializeField] private float currentPower;
    [SerializeField] private float powerRechargeRate = 2f;
    [SerializeField] private float timeToWaitForRecharge = 1f;
    private float currentPowerRechargeTimer;
    [SerializeField] private float timeBetweenCasts = 0.25f;
    private float currentCastTimer;
    private bool castingMagic = false;


    private void Awake()
    {
        playerInput = new PlayerInput(); 
        playerInput.Player.Jump.performed += OnJumpPressed;
        currentPower = maxPower;

    }

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        camera = FindObjectOfType<Camera>();
        
        
    }
    
    public void OnEnable()
    {
        playerInput.Player.Enable(); 
        playerInput.Powers.Enable(); 
        playerInput.PAUSE.Enable();
    }

    public void OnDisable()
    {
        playerInput.Player.Disable(); 
        playerInput.Powers.Disable(); 
        playerInput.PAUSE.Disable();
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
        Spells();
    }

    void Spells()
     {
      bool isSpellCastHeldDown = playerInput.Powers.Spell1.ReadValue<float>() > 0.1;
      bool isSpell2CastHeldDown = playerInput.Powers.Spell2.ReadValue<float>() > 0.1;
      bool isSpell3CastHeldDown = playerInput.Powers.Spell3.ReadValue<float>() > 0.1;
      bool hasEnoughPower = currentPower - spellToCast.SpellToCast.PowerCost >= 0f;
    
      if (!castingMagic && isSpellCastHeldDown && hasEnoughPower)
      {
          castingMagic = true;
          currentPower -= spellToCast.SpellToCast.PowerCost;
          currentCastTimer = 0;
          currentPowerRechargeTimer = 0;
          cas.CastSpell();
      }
    
      if (!castingMagic && isSpell2CastHeldDown && hasEnoughPower)
      {
          castingMagic = true;
          currentPower -= spellToCast.SpellToCast.PowerCost;
          currentCastTimer = 0;
          currentPowerRechargeTimer = 0;
          cas.CastSpell2();
      }
    
      if (!castingMagic && isSpell3CastHeldDown && hasEnoughPower)
      {
          castingMagic = true;
          currentPower -= spellToCast.SpellToCast.PowerCost;
          currentCastTimer = 0;
          currentPowerRechargeTimer = 0;
          cas.CastSpell3();
      }
    
      if (castingMagic)
      {
          currentCastTimer += Time.deltaTime;
    
          if (currentCastTimer > timeBetweenCasts)
          {
              castingMagic = false;
          }
      }
    
      if (currentPower < maxPower && !castingMagic && (!isSpellCastHeldDown || !isSpell2CastHeldDown || !isSpell3CastHeldDown))
      {
    
          currentPowerRechargeTimer += Time.deltaTime;
    
          if (currentPowerRechargeTimer > timeToWaitForRecharge)
          {
    
              currentPower += powerRechargeRate * Time.deltaTime;
    
              if (currentPower > maxPower)
              {
                  currentPower = maxPower;
              }
    
          }
    
     }
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
            text.SetActive(true);
            StartCoroutine(Text());
            
            Debug.Log("entrou");

            if (cas.countF == 1 && cas.countAnimais == 1 && cas.countSilvas == 1) 
            {
                text.SetActive(false);
                Destroy(collision.gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Lock2"))
        {
            text.SetActive(true);
            StartCoroutine(Text());
            
            if (cas.countF == 5 && cas.countAnimais == 3 && cas.countSilvas == 3) //1 anterior+ 4 novas
            {
                text.SetActive(false); 
                Destroy(collision.gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Lock3"))
        {
            text.SetActive(true);
            StartCoroutine(Text());
            
            if (cas.countF == 14 && cas.countAnimais == 6 && cas.countSilvas == 6)
            {
                text.SetActive(false); 
                Destroy(collision.gameObject);
            }
        }
        else if (collision.gameObject.tag == "Lock4")
        {
            text.SetActive(true);
            StartCoroutine(Text());
            
            if (cas.countF == 26) //test
            {
                text.SetActive(false); 
                Destroy(collision.gameObject);
            }
        }
        
    }

    IEnumerator Text()
    {
        Debug.Log("iii");
         
        yield return new WaitForSeconds(1.2f);
        text.SetActive(false);

    }
}
