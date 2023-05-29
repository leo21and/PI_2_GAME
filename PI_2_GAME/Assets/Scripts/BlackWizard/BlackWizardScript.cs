using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class BlackWizardScript : MonoBehaviour
{
    private Animator mAnimator;

    // Characters
    [Header ("Characters Prefabs")]
    public Transform Player;

    [Header("Attack Prefabs")]
    public GameObject plant1Prefab;
    public GameObject plant2Prefab;
    public GameObject plant3Prefab;
    private GameObject plant; 
    [SerializeField] GameObject Thunder;
    [SerializeField] ParticleSystem UpBeam;
    [SerializeField] ParticleSystem FrontBeam;

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

    [Header("Health")]
    public int blackWizardLife;
    public int currentBlackWizardHealth; 
    public BlackWizardHealth healthBar;
    public GameObject gameOverMenu;
    public bool BWDeath;

    [Header("Spell 2 Damage")]
    public int spell2Damage;
    [SerializeField] AudioSource AudioSourceBW;
    [SerializeField] AudioClip HurtClip;
    Collisions collission;

    [Header("Geral")]
    // Spawn Position
    public Vector3 spawnOffset;

    // Times
    public float spawnTime;
    public float spawnDelay;

    // Number of plants each spawn
    public int numPlants;

    public bool wizardDeath;
    [SerializeField] private GameObject healthbar;
    
    
    public bool isDeath;
    [SerializeField] private GameObject cutfinal;

    public Material skyMaterial;




    // Start is called before the first frame update
    void Start()
    {
        //
        mAnimator = GetComponent<Animator>();


        // Check if player is in the area
        InvokeRepeating("WizardAttack", spawnTime, spawnDelay);
        Thunder.SetActive(false);

        //Health do BlackWizard
        currentBlackWizardHealth = blackWizardLife;
        healthBar.SetMaxHealth(blackWizardLife);

        wizardDeath = false;
        isDeath = false;



    }

    // Update is called once per frame
    void Update()
    {
        if (currentBlackWizardHealth <= 0 && !isDeath)
        {
            BWDeath = true;
            StartCoroutine(BWDied());  
        }
    }

    public void BlackWizardSpell2Damage()
    {
        
        Debug.Log("Dano no Black Wizard com Spell 2");
        currentBlackWizardHealth = (currentBlackWizardHealth - spell2Damage);
        if (currentBlackWizardHealth > 0)
        {
            AudioSourceBW.PlayOneShot(HurtClip);
            healthBar.SetHealth(currentBlackWizardHealth);
        }

    }

    void WizardAttack()
    {

        float distance = Vector3.Distance(Player.position, transform.position);
        if (distance <= distance1 && distance >= (distance2+1) && BWDeath == false)
        {
            if (sendPlant1)
            {
                mAnimator.SetTrigger("TrPlant");
                Invoke("SendFrontBeam", 1);
                plant = plant1Prefab;
                Invoke("SpawnPlant", 1.5f);
            }
            if (sendThunder1)
            {
                mAnimator.SetTrigger("TrThunder");
                Invoke("SendUpBeam", 0.75f);
                Invoke("SendThunder",2);
                
                Debug.Log("isattacking");

            }
            
        }
        else if (distance <= distance2 && distance >= (distance3+1) && BWDeath == false)
        {
            if (sendPlant2)
            {
                mAnimator.SetTrigger("TrPlant");
                Invoke("SendFrontBeam", 1);
                plant = plant2Prefab;
                Invoke("SpawnPlant", 1.5f);

            }
            if (sendThunder2)
            {
                mAnimator.SetTrigger("TrThunder");
                Invoke("SendUpBeam", 0.75f);
                Invoke("SendThunder", 2);

            }

        }
        else if (distance <= distance3 && BWDeath == false)
        {
            if (sendPlant3)
            {
                mAnimator.SetTrigger("TrPlant");
                Invoke("SendFrontBeam", 1);
                plant = plant3Prefab;
                Invoke("SpawnPlant", 1.5f);
            }
            if (sendThunder3)
            {
                mAnimator.SetTrigger("TrThunder");
                Invoke("SendUpBeam", 0.75f);
                Invoke("SendThunder", 2);

            }

        }
    }

    IEnumerator BWDied()
    {
        isDeath = true;

        RenderSettings.skybox = skyMaterial;
       
        cutfinal.SetActive(true);
        
        healthbar.SetActive(false);
        mAnimator.SetTrigger("IsDeath");

        yield return new WaitForSeconds(4f);
    
        wizardDeath = true;
    }

    void SpawnPlant()
    {
        Vector3 newPosition = Player.transform.position + spawnOffset;
        for (int i = 1; i <= numPlants; i++) {
      
            Instantiate(plant, newPosition, Quaternion.identity);
        }


    }
    void SendUpBeam()
    {
        UpBeam.Play();
    }

    void SendThunder()
    {
        Vector3 position = Player.transform.position + new Vector3(0,40,0);
        Quaternion rot = Quaternion.Euler(90, 0, 0);
        //Debug.Log(position);
        GameObject raio = Instantiate(Thunder, position, rot);
        raio.SetActive(true);
        Destroy(raio, 1.00f);
        MusicManager.instance.SendThunderSFX();
    }

    void SendFrontBeam()
    {
        FrontBeam.Play(); 
    }

    IEnumerator test()
    {
        yield return new WaitForSeconds(20);
        wizardDeath = true;
    }

}
