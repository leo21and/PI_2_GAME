using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{ 
    [SerializeField] public int playerLife;
    public int currentHealth;
    [SerializeField] private int regenHealth;
    
    public List<GameObject> flowers = new List<GameObject>();
    public int damage = 1;
    public GameObject player;
    public bool startTakingLife;
    private int flowerNumInRange;

    private PlayerInput playerInput;

    
    public CharacterController playercc;
    private Animator playeranimator;
    private int deathTime;

    public GameObject gameOverMenu;

    public bool death;
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject maincam;
    private PlayerController pc;

  

    // Start is called before the first frame update
    void Start()
    {
        startTakingLife = false;
        death = false;

        currentHealth = playerLife;

        playerInput = new PlayerInput();

        playeranimator = GetComponent<Animator>();

        StartCoroutine(regenPlayerHealth());

        pc = GetComponent<PlayerController>();



    }
    
   

    // Update is called once per frame
    void Update()
    {
        
        
        Damage();
        
        
    }
    

    private void Damage()
    
    {
        foreach (GameObject flower in flowers)
       {
           float dist = Vector3.Distance(player.transform.position, flower.transform.position);

           if ( dist < 5 && flower.GetComponent<FlowersToxic>().flowerHeal == false)
           {

               if (flower.GetComponent<FlowersToxic>().countedFlower == false)
               {
                   flowerNumInRange++;
                   flower.GetComponent<FlowersToxic>().countedFlower = true;

               }
               if (!startTakingLife && flowerNumInRange > 0 && currentHealth > 0) //&&currenthealth > 0
               {
                   StartCoroutine(TakeLife());

                  
               }
               
               else if (currentHealth <= 908 && !death) //mudar para zero //908
               {
             
                   StartCoroutine(PrefomerAnim());

               }
           }
       }
        
       // Debug.Log(flowerNumInRange + "flowers");
    }

    IEnumerator TakeLife()
    {
        startTakingLife = true;

        yield return new WaitForSeconds(1f);

        //default damage a 1 mudar se quisermos no inspector

        
        int total = damage * flowerNumInRange;        
        currentHealth -= total; 
        //Meter som de dano ou animação
        Debug.Log(currentHealth + "current");

      
        startTakingLife = false;
        flowerNumInRange = 0;

        foreach (GameObject flower in flowers)
        {
            flower.GetComponent<FlowersToxic>().countedFlower = false;
 
        }
    }

    IEnumerator regenPlayerHealth()
    {
        while (true)
        {
            if (currentHealth < playerLife)
            {
                if (currentHealth + regenHealth > playerLife)
                {
                    currentHealth = playerLife;
                }
                else
                {
                    currentHealth += regenHealth;
                    Debug.Log(currentHealth + "renovada"); 
                }

                yield return new WaitForSeconds(2); //2 ou 1.tal, ver dp no balance
            }
            else
            {
                yield return null;
            }
        }
    }

    public void GoBackToLastLock()
    {
        playercc.enabled = false;
        pc.OnEnable(); 
        
        
        if(GameObject.Find("FourthLock") == null)
        {
            gameObject.transform.position = new Vector3(0.79f, 0f, 310f);
        }
        else if (GameObject.Find("ThirdLock") == null)
        {
            gameObject.transform.position = new Vector3(0.79f, 0f, 207f);
        }
        else if (GameObject.Find("SecondLock") == null)
        {
            gameObject.transform.position = new Vector3(0.79f, 0f, 92.4f);
        }
        else if (GameObject.Find("FirstLock") == null)
        {
            gameObject.transform.position = new Vector3(0.79f, 0f, 36.9f);
        }

        playercc.enabled = true;
        currentHealth = playerLife;
        
        deathTime++;
        Debug.Log(deathTime);
    }


    IEnumerator PrefomerAnim()
    {
        death = true;
              
        pc.OnDisable();

        cam.transform.Rotate(50,0,0 );
     
        cam.transform.position = player.transform.position + new Vector3(0,13,-9);
        
        maincam.SetActive(false);
        cam.SetActive(true);
        playeranimator.SetTrigger("IsDeath");
        

        yield return new WaitForSeconds(5);
        
        cam.SetActive(false);
        maincam.SetActive(true);
        cam.transform.Rotate(-50,0,0);
        
      
               
        if (deathTime < 2)
        { 
            GoBackToLastLock();  
        }
        else
        {
            gameOverMenu.SetActive(true);
            currentHealth = playerLife;
        }

        death = false;
        
    }

    
  
}
