using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectOtherPlants : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collider col)
    {
        if (col.name == "Flower_1")
        {
            Destroy(this);
        }
    }
}
