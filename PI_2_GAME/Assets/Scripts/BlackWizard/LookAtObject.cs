using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour
{
    [SerializeField] Transform player;
    void Update()
    {
        transform.LookAt(player);
    }
    


}
