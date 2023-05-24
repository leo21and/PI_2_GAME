using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class OwlMovement : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float z ;
    [SerializeField] private PlayerController pc;
    private Vector3 lastPos;
    Vector3 currentVelocity = Vector3.zero;

    private Rigidbody rb;
    [SerializeField] private GameObject cutInicial, cutFinal;

    [Header("OwlSound")]
    private AudioSource owl;
    public float minWaitTime = 1f;
    public float maxWaitTime = 5f;
    public float waitCountdown = -1f;
    
    
     

    // Start is called before the first frame update
    void Start()
    { 
        
        lastPos = transform.position;
        rb = GetComponent<Rigidbody>();
        owl = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (cutInicial.activeSelf)
        {
            transform.rotation = Quaternion.Euler(0,202,0);
        }
         if (Input.GetKeyDown(KeyCode.A))
         {
            transform.rotation = Quaternion.Euler(0,-90,0); 
         }
         else if (Input.GetKeyDown(KeyCode.D)) 
         {
             transform.rotation = Quaternion.Euler(0,90,0);  
         }
         else if (Input.GetKeyDown(KeyCode.S)) 
         {
             transform.rotation = Quaternion.Euler(0,202,0);  
         }
         else if (Input.GetKeyDown(KeyCode.W)) 
         {
             transform.rotation = Quaternion.Euler(0,25,0);  
         }

         // transform.position = Vector3.Lerp(transform.position,  player.transform.position + new Vector3(x,y,z) , 5 * Time.deltaTime);
             // transform.position = Vector3.MoveTowards(transform.position,  player.transform.position + new Vector3(x,y,z) , 5 * Time.deltaTime);
             Vector3 targetPosition = player.transform.position + new Vector3(x, y, z);
             Vector3 target2Position = player.transform.position + new Vector3(0, y, z);
             Vector3 direction = targetPosition - transform.position;
             float distance = direction.magnitude;
             direction.Normalize();


             RaycastHit hit;


             if (Physics.SphereCast(transform.position, 0.5f, direction, out hit, distance))
             {

                 if (hit.collider.gameObject.CompareTag("Terrain"))
                 {
                     Vector3 newPos = hit.point + hit.normal;
                     transform.position = newPos;

                 }
             }
             else
             {
                 transform.position = Vector3.MoveTowards(transform.position, targetPosition, 10 * Time.deltaTime);
             
             Debug.DrawLine(transform.position, transform.position + direction * distance, Color.red);
             Debug.DrawRay(hit.point, hit.normal, Color.green);
             Debug.DrawRay(hit.point, direction * hit.distance, Color.blue);

             }


             //OWL RANDOM SOUND 
             if (!owl.isPlaying && !cutInicial.activeSelf && !cutFinal.activeSelf)
             {
                 if (waitCountdown < 0f)
                 {
                     owl.Play();
                     waitCountdown = Random.Range(minWaitTime, maxWaitTime);
                 }
                 else
                 {
                     waitCountdown -= Time.deltaTime;
                 }
             }
    }
    
    
}
