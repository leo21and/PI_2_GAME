using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms;

public class PlayerMagic : MonoBehaviour
{
   

    private PlayerInput playerInput;

    public List<GameObject> Animals = new List<GameObject>();
    public List<GameObject> Silvas = new List<GameObject>();

    public int countAnimais;
    public int countSilvas;
    public int countF;

    public GameObject AnimalCollected;
    public GameObject SilvaCollected;
    public GameObject FlowerCollected;

    private bool isWaitingF;
    private bool isWaitingA;
    private bool isWaitingS;

    private float timer = 0.7f;
    [SerializeField] private Transform castPoint;

    [SerializeField] private TMP_Text flower_text;
    [SerializeField] private TMP_Text animal_text;
    [SerializeField] private TMP_Text silva_text;

    public Camera cam;
    public float range = 100f;
    public float impactForce = 30f;
    public GameObject impactEffect;


    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Update()
    {
        
    }

    
}
