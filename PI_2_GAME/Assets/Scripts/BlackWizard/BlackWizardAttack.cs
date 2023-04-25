using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackWizardAttack : MonoBehaviour
{
    private Animator mAnimator;

    // Characters
    [Header ("Characters Prefabs")]
    public Transform Player;
    public Transform BlackWizard;

    [Header("Attack Prefabs")]
    public GameObject plant1Prefab;
    public GameObject plant2Prefab;
    public GameObject plant3Prefab;
    private GameObject plant; 
    [SerializeField] GameObject Thunder;
    [SerializeField] GameObject UpBeam;
    [SerializeField] GameObject FrontBeam;

    [Header("Attack Level 1")]
    public float distance1;
    public bool sendPlant1;
    public bool sendThunder1;

    [Header("Attack Level 2")]
    public float distance2;
    public bool sendPlant2;
    public bool sendThunder2;

    [Header("Attack Level 3")]
    public float distance3;
    public bool sendPlant3;
    public bool sendThunder3;

    [Header("Geral")]
    // Spawn Position
    public Vector3 spawnOffset;

    // Times
    public float spawnTime;
    public float spawnDelay;

    // Number of plants each spawn
    public int numPlants;

    

    // Start is called before the first frame update
    void Start()
    {
        //
        mAnimator = GetComponent<Animator>();


        // Check if player is in the area
        InvokeRepeating("WizardAttack", spawnTime, spawnDelay);
        Thunder.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


    }

    void WizardAttack()
    {

        float distance = Vector3.Distance(Player.position, BlackWizard.position);
        if (distance <= distance1 && distance >= (distance2+1))
        {
            if (sendPlant1)
            {
                mAnimator.SetTrigger("TrPlant");
                Invoke("SendFrontBeam", 1);
                plant = plant1Prefab;
                Invoke("SpawnPlant", 2);
            }
            if (sendThunder1)
            {
                mAnimator.SetTrigger("TrThunder");
                Invoke("WizardLightning", 1);
                Invoke("SendThunder",2);

            }
            
        }
        else if (distance <= distance2 && distance >= (distance3+1))
        {
            if (sendPlant2)
            {
                mAnimator.SetTrigger("TrPlant");
                Invoke("SendFrontBeam", 1);
                plant = plant2Prefab;
                Invoke("SpawnPlant", 2);

            }
            if (sendThunder2)
            {
                mAnimator.SetTrigger("TrThunder");
                Invoke("WizardLightning", 1);
                Invoke("SendThunder", 2);

            }

        }
        else if (distance <= distance3)
        {
            if (sendPlant3)
            {
                mAnimator.SetTrigger("TrPlant");
                Invoke("SendFrontBeam", 1);
                plant = plant3Prefab;
                Invoke("SpawnPlant", 2);
            }
            if (sendThunder3)
            {
                mAnimator.SetTrigger("TrThunder");
                Invoke("WizardLightning", 1);
                Invoke("SendThunder", 2);

            }

        }
    }


    void SpawnPlant()
    {
        for (int i = 1; i <= numPlants; i++) {
            Vector3 newPosition = Player.transform.position + spawnOffset;
            switch (i)
            {
                case 1:
                    Instantiate(plant, newPosition, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(plant, newPosition, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(plant, newPosition, Quaternion.identity);
                    break;
            }


        }


    }
    void WizardLightning()
    {
        Vector3 position = BlackWizard.transform.position + new Vector3(0, 3, 0);
        Quaternion rot = Quaternion.Euler(-90, 0, 0);
        //Debug.Log(position);
        GameObject raio = Instantiate(UpBeam, position, rot);
        raio.SetActive(true);
        Destroy(raio, 1.00f);
    }

    void SendThunder()
    {
        Vector3 position = Player.transform.position + new Vector3(0,40,0);
        Quaternion rot = Quaternion.Euler(90, 0, 0);
        //Debug.Log(position);
        GameObject raio = Instantiate(Thunder, position, rot);
        raio.SetActive(true);
        Destroy(raio, 1.00f);
    }

    void SendFrontBeam()
    {
        Vector3 position = BlackWizard.transform.position + new Vector3(0, 3, 0);
        Quaternion rot = Quaternion.Euler(180, 0, 0);
        Debug.Log(position);
        GameObject raio = Instantiate(FrontBeam, position, rot);
        raio.SetActive(true);
        Destroy(raio, 1.00f);
    }

}
