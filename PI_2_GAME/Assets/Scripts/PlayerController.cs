using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] private float maxPower = 100f;
    [SerializeField] private float currentPower;
    [SerializeField] private float powerRechargeRate = 2f;
    [SerializeField] private float timeToWaitForRecharge = 1f;
    private float currentPowerRechargeTimer;
    [SerializeField] private float timeBetweenCasts = 0.25f;
    private float currentCastTimer;
    private bool castingMagic = false;
    int selectedSpell;

    public GameObject mira;
    public Slider currentPowerUI;
    [SerializeField] private Transform castPoint;

    [SerializeField] private GameObject spellCircleFlowers;
    [SerializeField] private GameObject spellCircleSilvas;
    [SerializeField] private GameObject spellCircleAnimals;
    [SerializeField] private GameObject spell3;
    [SerializeField] private GameObject spell2;
    [SerializeField] private GameObject spell1;

    private bool uiSpellA;
    private bool uiSpellF;
    private bool uiSpellS;

    // Potion UI Status
    public PotionScript PotionUI;

    public bool canCastSpell;
    public bool ismoving;






    public int zona;

    private void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.Player.Jump.performed += OnJumpPressed;
        currentPower = maxPower;
        currentPowerUI.maxValue = maxPower;

    }

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        camera = FindObjectOfType<Camera>();

        uiSpellA = false;
        uiSpellF = false;
        uiSpellS = false;

        canCastSpell = true;



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
        currentPowerUI.value = currentPower;


        Move();
        Jump();
        Spells();


    }

    void Spells()
    {

        for (int i = 0; i < cas.spellToCast.Length; i++)
        {
            bool isSpellCastHeldDown = playerInput.Powers.CastSpell.ReadValue<float>() > 0.1;

            bool hasEnoughPower = currentPower - cas.spellToCast[i].SpellToCast.PowerCost >= 0f;

           // bool isAiming = playerInput.Powers.Aim.ReadValue<float>() > 0.1;




            if (Input.GetKeyDown(KeyCode.Alpha1) && canCastSpell)
            {
                selectedSpell = 0;

                if (uiSpellS)
                {
                    Debug.Log("stop2");
                    StopCoroutine("Spell2UI");

                    spellCircleSilvas.SetActive(false);
                    spell2.SetActive(false);

                    uiSpellS = false;
                }
                else if (uiSpellF)
                {
                    Debug.Log("stop3");
                    StopCoroutine("Spell3UI");

                    spellCircleFlowers.SetActive(false);
                    spell3.SetActive(false);

                    uiSpellF = false;
                }

                if (uiSpellA == false)
                {
                    Debug.Log("entrou no 1");
                    StartCoroutine("Spell1UI");

                    mira.SetActive(false);
                    currentPowerUI.gameObject.SetActive(false);
                    StopCoroutine("Mira");
                    StopCoroutine("CurrentPowerUI");

                    StartCoroutine("Mira");
                    StartCoroutine("CurrentPowerUI");


                }


            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && canCastSpell)
            {
                selectedSpell = 1;

                if (uiSpellA)
                {
                    StopCoroutine("Spell1UI");

                    spellCircleAnimals.SetActive(false);
                    spell1.SetActive(false);
                    uiSpellA = false;
                }
                else if (uiSpellF)
                {
                    StopCoroutine("Spell3UI");

                    spellCircleFlowers.SetActive(false);
                    spell3.SetActive(false);
                    uiSpellF = false;
                }

                if (uiSpellS == false)
                {
                    Debug.Log("entrou no 2");
                    StartCoroutine("Spell2UI");

                    mira.SetActive(false);
                    currentPowerUI.gameObject.SetActive(false);
                    StopCoroutine("Mira");
                    StopCoroutine("CurrentPowerUI");

                    StartCoroutine("Mira");
                    StartCoroutine("CurrentPowerUI");



                }

            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && canCastSpell)
            {
                selectedSpell = 2;


                if (uiSpellS)
                {
                    StopCoroutine("Spell2UI");

                    spellCircleSilvas.SetActive(false);
                    spell2.SetActive(false);
                    uiSpellS = false;
                }
                else if (uiSpellA)
                {
                    StopCoroutine("Spell1UI");

                    spellCircleAnimals.SetActive(false);
                    spell1.SetActive(false);
                    uiSpellA = false;
                }

                if (uiSpellF == false)
                {

                    Debug.Log("entrou no 3");
                    StartCoroutine("Spell3UI");


                    mira.SetActive(false);
                    currentPowerUI.gameObject.SetActive(false);
                    StopCoroutine("Mira");
                    StopCoroutine("CurrentPowerUI");

                    StartCoroutine("Mira");
                    StartCoroutine("CurrentPowerUI");


                }


            }
            // Debug.Log(isAiming);
            //
            // if (isAiming)
            // {
            //
            //     StartCoroutine("Mira2");
            //     StartCoroutine("CurrentPowerUI2");
            //
            // }




            if (!castingMagic && isSpellCastHeldDown && hasEnoughPower)
            {
                castingMagic = true;
                currentPower -= cas.spellToCast[i].SpellToCast.PowerCost;
                currentCastTimer = 0;
                currentPowerRechargeTimer = 0;


                if (selectedSpell == 0)
                {
                    cas.CastSpell();
                    StopCoroutine("Spell1UI");
                    spellCircleAnimals.SetActive(false);
                    spell1.SetActive(false);
                    uiSpellA = false;

                }
                else if (selectedSpell == 1)
                {
                    cas.CastSpell2();
                    StopCoroutine("Spell2UI");
                    spellCircleSilvas.SetActive(false);
                    spell2.SetActive(false);
                    uiSpellS = false;


                }
                else if (selectedSpell == 2)
                {
                    cas.CastSpell3();
                    StopCoroutine("Spell3UI");
                    spellCircleFlowers.SetActive(false);
                    spell3.SetActive(false);
                    uiSpellF = false;


                }

            }




            if (castingMagic)
            {

                currentCastTimer += Time.deltaTime;

                if (currentCastTimer > timeBetweenCasts)
                {
                    castingMagic = false;
                }
            }

            if (currentPower < maxPower && !castingMagic && !isSpellCastHeldDown)
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




            if (currentPower > maxPower / 2)
            {

                currentPowerUI.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.green;

            }
            else if (currentPower > maxPower / 4 && currentPower < maxPower)
            {

                currentPowerUI.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.yellow;

            }
            else if (currentPower < maxPower / 4)
            {
                currentPowerUI.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.red;
            }

            PotionUI.setPotionValue((int)currentPower);
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

        if (horizontalMovement != Vector3.zero)
        {
            ismoving = true;
        }
        else
        {
            ismoving = false;
        }

    }

    //UnlockAreas

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lock1"))
        {
            text.SetActive(true);
            StartCoroutine(Text());


            if (cas.countF == 1 && cas.countAnimais == 1 && cas.countSilvas == 1)
            {
                text.SetActive(false);
                zona = 2;
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
                zona = 3;
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
                zona = 4;
                Destroy(collision.gameObject);
            }
        }
        else if (collision.gameObject.tag == "Lock4")
        {
            text.SetActive(true);
            StartCoroutine(Text());

            if (cas.countF == 20 && cas.countSilvas == 10 && cas.countAnimais == 10) //test
            {
                text.SetActive(false);
                zona = 5;
                Destroy(collision.gameObject);
            }
        }

   


    }

    IEnumerator Text()
    {

        yield return new WaitForSeconds(1.2f);
        text.SetActive(false);

    }



    IEnumerator Spell3UI()
    {


        uiSpellF = true;

        spellCircleFlowers.SetActive(true);

        //yield return new WaitForSeconds(2);
        spell3.SetActive(true);

        yield return new WaitForSeconds(5);
        spell3.SetActive(false);
        spellCircleFlowers.SetActive(false);

        uiSpellF = false;

    }

    IEnumerator Spell2UI()
    {

        uiSpellS = true;

        spellCircleSilvas.SetActive(true);

        // yield return new WaitForSeconds(2);
        spell2.SetActive(true);

        yield return new WaitForSeconds(5);
        spell2.SetActive(false);
        spellCircleSilvas.SetActive(false);

        uiSpellS = false;

    }

    IEnumerator Spell1UI()
    {

        uiSpellA = true;

        spellCircleAnimals.SetActive(true);

        //   yield return new WaitForSeconds(2);
        spell1.SetActive(true);

        yield return new WaitForSeconds(5);
        spell1.SetActive(false);
        spellCircleAnimals.SetActive(false);



        uiSpellA = false;


    }

    IEnumerator Mira()
    {
        yield return new WaitForSeconds(0.2f);
        mira.SetActive(true);
        yield return new WaitForSeconds(6f);
        mira.SetActive(false);

    }

    // IEnumerator Mira2()
    // {
    //     yield return new WaitForSeconds(0.2f);
    //     mira.SetActive(true);
    //     yield return new WaitForSeconds(10f);
    //     mira.SetActive(false);
    //
    // }

    IEnumerator CurrentPowerUI()
    {
        yield return new WaitForSeconds(0.2f);
        currentPowerUI.gameObject.SetActive(true);
        yield return new WaitForSeconds(6f);
        currentPowerUI.gameObject.SetActive(false);

    }
    IEnumerator CurrentPowerUI2()
    {
        yield return new WaitForSeconds(0.2f);
        currentPowerUI.gameObject.SetActive(true);
        yield return new WaitForSeconds(10f);
        currentPowerUI.gameObject.SetActive(false);

    }

}


