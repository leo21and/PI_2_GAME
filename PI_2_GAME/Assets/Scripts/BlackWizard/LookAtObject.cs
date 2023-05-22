using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour
{
    [SerializeField] Transform player;

    void Start()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }
    }

    void Update()
    {
        transform.LookAt(player);

        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }


    }
    


}
