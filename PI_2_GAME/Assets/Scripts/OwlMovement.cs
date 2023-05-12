using System.Collections;
using System.Collections.Generic;
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
    
     

    // Start is called before the first frame update
    void Start()
    { 
        
        lastPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
            
        // transform.position = Vector3.Lerp(transform.position,  player.transform.position + new Vector3(x,y,z) , 5 * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position,  player.transform.position + new Vector3(x,y,z) , 5 * Time.deltaTime);



    }
    
    
}
