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
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Flower" && newPlant == true)
        {
            Destroy(this);
        }
    }
 
}
