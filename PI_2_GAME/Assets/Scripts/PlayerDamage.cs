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

    public int countF;
    public CharacterController playercc;
    private Animator playeranimator;
    private int deathTime;
    
    

    // Start is called before the first frame update
    void Start()
    {
        startTakingLife = false;

        currentHealth = playerLife;

        playerInput = new PlayerInput();

        playeranimator = GetComponent<Animator>();

        StartCoroutine(regenPlayerHealth());

    }

    // Update is called once per frame
    void Update()
    {
        Damage();
        
       
        
    }

    //substituido por raycast provavelemnte numa class para todos os raycasts onde deves incluir isto e uma referencia a class das Flowerstoxic
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Toxic" && other.GetComponent<FlowersToxic>().flowerHeal == false)
        {
            other.GetComponent<FlowersToxic>().flowerHeal = true;
            countF++;


            Debug.Log(countF);

        }
    }

    private void Damage()
    {
        foreach (GameObject flower in flowers)
       {
           float dist = Vector3.Distance(player.transform.position, flower.transform.position); 
           //maybe substituir os dois ifs por && -> let's see se nao e preciso implementar mais nada
                    
           if ( dist < 5 && flower.GetComponent<FlowersToxic>().flowerHeal == false)
           {
               //Debug.Log("entrou2" + playerLife);

               
               if (flower.GetComponent<FlowersToxic>().countedFlower == false)
               {
                   flowerNumInRange++;
                   flower.GetComponent<FlowersToxic>().countedFlower = true;

               }
               if (!startTakingLife && flowerNumInRange > 0 && currentHealth > 0)
               {
                   StartCoroutine(TakeLife()); 
               }
               else if (currentHealth <= 908) //mudar para zero
               {
                   //IMPLEMENTAR MORTE
                   playeranimator.SetTrigger("IsDeath");


                 //  if (playeranimator.GetCurrentAnimatorStateInfo(0).IsName("Death") &&
                 //      (playeranimator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1))
                  // {
                       playerInput.Player.Disable();
                       playerInput.Powers.Disable();

                       if (deathTime <= 2)
                       { 
                           GoBackToLastLock();  
                       }
                       else
                       {
                           gameObject.transform.position = new Vector3(0.79f, 0f, 15f);
                           //mudar para aprecer o meu de restart 
                       }
                       
                  // }
                   
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
        
        //Debug.Log(total + "finaldamage"); 
       
        
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
        playerInput.Player.Enable();
        playerInput.Powers.Enable();
        deathTime++;
        Debug.Log(deathTime);
    }
    
    
}
