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
    public GameObject flowerPrefab;

    private GameObject plant; 
    [SerializeField] GameObject Thunder;
    [SerializeField] ParticleSystem UpBeam;
    [SerializeField] ParticleSystem FrontBeam;
    public float attackDistance;


    [Header("Health")]
    public int blackWizardLife;
    public int currentBlackWizardHealth; 
    public BlackWizardHealth healthBar;
    public GameObject gameOverMenu;
    public bool BWDeath;

    [Header("Spell 2 Damage")]
    public int spell2Damage;
    Collisions collission;

    [Header("Death")]
    public bool wizardDeath;
    public GameObject respawnFlower1;
    [SerializeField] ParticleSystem BWParticles1;
    [SerializeField] ParticleSystem BWParticles2;
    [SerializeField] ParticleSystem BWParticles3;
    public GameObject[] respawns;



    [Header("Geral")]
    // Spawn Position
    public Vector3 spawnOffset;

    // Times
    public float spawnTime;
    public float spawnDelay;

    // Number of plants each spawn
    public int numPlants;

    
    [SerializeField] private GameObject healthbar;

    [Header("CutSceneFinal")]
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
          //  MusicManager.instance.BWHurt();
            healthBar.SetHealth(currentBlackWizardHealth);
        }

    }

    void WizardAttack()
    {

        float distance = Vector3.Distance(Player.position, transform.position);
        if (distance <= attackDistance && BWDeath == false && isDeath == false)
        {
            if (Random.value >= 0.5)
            {
                mAnimator.SetTrigger("TrPlant");
                Invoke("SendFrontBeam", 1);
                plant = flowerPrefab;
                Invoke("SpawnPlant", 1.5f);
            } else
            {
                mAnimator.SetTrigger("TrThunder");
                Invoke("SendUpBeam", 0.75f);
                Invoke("SendThunder", 2);
                Debug.Log("isattacking");
            }
            



        }
        
        else if (distance <= 150 && BWDeath == false && isDeath == false)
        {
            healthbar.SetActive(true);
         
        }

    }

    IEnumerator BWDied()
    {
        isDeath = true;

        //Eliminar todas as plantas (podemos trocar por desintoxicar as plantas
            respawns = GameObject.FindGameObjectsWithTag("Flower");

            foreach (GameObject respawn in respawns)
            {
                Destroy(respawn);
            }

        MusicManager.instance.BWDeath();

        //Remover o Mesh do Feiticeiro
        BWParticles1.Stop();
        BWParticles2.Stop();
        BWParticles3.Stop();

        RenderSettings.skybox = skyMaterial;
       
        cutfinal.SetActive(true);
        
        healthbar.SetActive(false);

        mAnimator.SetTrigger("IsDeath");

        yield return new WaitForSeconds(2f);



        yield return new WaitForSeconds(2f);
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
        MusicManager.instance.BWLaser();
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
        MusicManager.instance.BWSerpentSpell();
        FrontBeam.Play(); 
    }

    IEnumerator test()
    {
        yield return new WaitForSeconds(20);
        wizardDeath = true;
    }

}
