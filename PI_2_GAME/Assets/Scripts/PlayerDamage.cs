using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{ 
    [SerializeField] public int playerLife;
    
    public List<GameObject> flowers = new List<GameObject>();
    public int damage = 1;
    public GameObject player;
    public bool startTakingLife;
    private int flowerNumInRange;

    

   
    

    // Start is called before the first frame update
    void Start()
    {
        startTakingLife = false;

    }

    // Update is called once per frame
    void Update()
    {
        Damage();
        

    }

    //substituido por raycast provavelemnte numa class para todos os raycasts onde deves incluir isto e uma referencia a class das Flowerstoxic
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Toxic")
        {
            other.GetComponent<FlowersToxic>().flowerHeal = true;
            
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
               
               
               if (!startTakingLife && flowerNumInRange > 0)
               {
                  StartCoroutine(TakeLife()); 
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
        playerLife -= total; 
        
        Debug.Log(total + "finaldamage"); 
        
        startTakingLife = false;
        flowerNumInRange = 0;

        foreach (GameObject flower in flowers)
        {
            flower.GetComponent<FlowersToxic>().countedFlower = false;
 
        }
    }
}
