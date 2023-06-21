using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectOtherPlants : MonoBehaviour
{
    private bool newPlant;
    // Start is called before the first frame update
    void Start()
    {
        newPlant = true;
    }

    // Update is called once per frame
    void Update()
    {
        newPlant = false;
    }
    private void OnTriggerEnter(Collider other)
    {
      
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "_FlowerToxic" && newPlant == true)
        {
            //Destroy(this.gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "_FlowerToxic")
        {
            Destroy(this.gameObject);
        }
    }
}
