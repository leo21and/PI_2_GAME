using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionsAnimalsSilvas : MonoBehaviour
{
    public List<GameObject> Animals = new List<GameObject>();
    public List<GameObject> Silvas = new List<GameObject>();

    public int countAnimais;
    public int countSilvas;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Animais" && other.GetComponent<Animais>().animalSaved == false)
        {
            other.GetComponent<Animais>().animalSaved = true;
            countAnimais++;
        }

        if (other.gameObject.tag == "Silvas" && other.GetComponent<Silvas>().silvaClean == false)
        {
            other.GetComponent<Silvas>().silvaClean = true;
            countSilvas++;
        }
    }
}
