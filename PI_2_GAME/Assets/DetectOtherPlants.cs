using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectOtherPlants : MonoBehaviour
{
    private bool newPlant;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
      
        Debug.Log(other.gameObject.GetInstanceID());
        
        if (other.gameObject.name == "_FlowerToxic")
        {
            if (other.gameObject.GetInstanceID() > this.gameObject.GetInstanceID())
            {
                Destroy(this.gameObject);
            }
            
        }
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "_FlowerToxic")
        {
            //Destroy(this.gameObject);
        }
    }
}
