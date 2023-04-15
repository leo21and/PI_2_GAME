using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackWizardAttack : MonoBehaviour
{
    // Characters
    public Transform WhiteWizard;
    public Transform BlackWizard;

    // Plants
    public GameObject plant1Prefab;
    public GameObject plant2Prefab;
    public GameObject plant3Prefab;

    // Spawn Position
    public Vector3 spawnOffset;

    // Times
    public float spawnTime;
    public float spawnDelay;

    // Number of plants each spawn
    public int numPlants;

   

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("WizardAttack", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void WizardAttack()
    {

        float distance = Vector3.Distance(WhiteWizard.position, BlackWizard.position);
        if (distance <= 35 && distance >= 26)
        {
            SpawnObject(plant1Prefab);
        }
        else if (distance <= 25 && distance >= 16)
        {
            SpawnObject(plant2Prefab);
        }
        else if (distance <= 15)
        {
            SpawnObject(plant3Prefab);
        }
    }

    public void SpawnObject(GameObject plant)
    {

        for (int i = 1; i <= numPlants; i++) {
            Vector3 newPosition = WhiteWizard.transform.position + spawnOffset;
            switch (i)
            {
                case 1:
                    Instantiate(plant, newPosition, Quaternion.identity);
                    break;
                case 2:
                    newPosition.x = newPosition.x - 3;
                    Instantiate(plant, newPosition, Quaternion.identity);
                    break;
                case 3:
                    newPosition.x = newPosition.x + 3;
                    Instantiate(plant, newPosition, Quaternion.identity);
                    break;
            }


        }


    }
}
