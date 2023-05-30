using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class AnimalsMovement : MonoBehaviour
{
    public float speed = 10f;

    public float rotationspeed = 100f;

    private bool rotleft;
    private bool rotright;
    private bool iswalking;
    private bool iswandering;

    private Animais animais;
    private Rigidbody rb;
    public float avoidDistance = 0.5f;
    public float raycastDistance = 1f;

    [SerializeField] private Animator rabbit;
    [SerializeField] private StarBehsviour s;
    [SerializeField] private AudioSource aHappy;
    private bool startsound;
    
    // Start is called before the first frame update
    void Start()
    {

        startsound = false;
        rotleft = false;
        rotright = false;
        iswalking = false;
        iswandering = false;
        
        animais = GetComponent<Animais>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (!startsound && animais.animalSaved)
        {
            StartCoroutine(playWalkHappy()); 
            Debug.Log("O áudio está sendo reproduzido!");
        }

        if (animais.animalSaved && s.trigou)
        {
            if (!iswandering)
            {
                StartCoroutine(Wander()); 
            }

            if (rotright)
            {
                transform.Rotate(transform.up * Time.deltaTime * rotationspeed);
            }

            if (rotleft)
            {
                transform.Rotate(transform.up * Time.deltaTime * -rotationspeed);
            }

            if (iswalking)
            {
                RaycastHit hit;

                if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
                {
                    if (hit.distance < avoidDistance)
                    {
                        if (Random.value > 0.5f)
                        {
                            rotright = true;
                        }
                        else
                        {
                            rotleft = true;
                        }
                    }
                   
                }
                else
                {
                    rb.transform.position += transform.forward * speed; 
                    
                }
               
                //animation aqui de andar
            }
            //
            // if (!iswalking)
            // {
            //     //parar a animation de andar -> bool 
            // }
            
            rabbit.SetBool("Walk", true);
            
            
           

        }
    }

    private IEnumerator Wander()
    {
        int rottime = Random.Range(1, 3);
        int rotWait = Random.Range(1, 3);
        int rotDir = Random.Range(1, 2);
        int walkWait = Random.Range(1, 3);
        int walkTime = Random.Range(1, 3);

        iswandering = true;
        yield return new WaitForSeconds(walkWait);
        
        iswalking = true;
        yield return new WaitForSeconds(walkTime);

        iswalking = false;
        yield return new WaitForSeconds(rotWait);

        if (rotDir == 1)
        {
            rotleft = true;
            yield return new WaitForSeconds(rottime);
            rotleft = false;
        }
        else if(rotDir == 2)
        {
            rotright = true;
            yield return new WaitForSeconds(rottime);
            rotright = false;
        }

        iswandering = false;

    }

    private IEnumerator playWalkHappy()
    {
        startsound = true;
        yield return new WaitForSeconds(6);
        aHappy.Play();
        yield return new WaitForSeconds(14); //if is not playing, mas isto e para cortar o final do audio que e de 15qualquer coisa
        startsound = false;
    }
}
