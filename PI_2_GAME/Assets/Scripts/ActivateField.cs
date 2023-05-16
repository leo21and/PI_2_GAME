using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateField : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject field;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "fonte")
        {
           StartCoroutine(fieldActivate());
        }
    }

    IEnumerator fieldActivate()
    {
        field.SetActive(true);
        yield return new WaitForSeconds(12);
        
        field.SetActive(false);
    }
}
