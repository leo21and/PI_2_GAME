using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneActivate : MonoBehaviour
{

    [SerializeField] private GameObject cut1;
    [SerializeField] private GameObject cut2;
    [SerializeField] private GameObject cut3;

    public bool disable ;
    

    
    

    // Start is called before the first frame update
    void Start()
    {
        disable = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cut1")
        {
            disable = true;
            cut1.SetActive(true);
            
        }
        
        else if (other.tag == "Cut2")
        {
            disable = true;
            cut2.SetActive(true);
        }
        
        else if (other.tag == "Cut3")
        {

            disable = true;
            cut3.SetActive(true);
        }

    }
}