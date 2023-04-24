using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{  public GameObject player;
    private Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        //distance between the camera and player
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //makethe camera position always in the same distance to the player 
        transform.position = player.transform.position + offset;
    }
}
