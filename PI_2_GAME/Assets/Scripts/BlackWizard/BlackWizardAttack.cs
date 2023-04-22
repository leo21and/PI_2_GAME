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

    // VFX Effects
    [SerializeField] GameObject Vfx;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("WizardAttack", spawnTime, spawnDelay);
        Vfx.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void WizardAttack()
    {

        float distance = Vector3.Distance(WhiteWizard.position, BlackWizard.position);
        if (distance <= 75 && distance >= 56)
        {
            SpawnObject(plant1Prefab);
            WizardLightning();
            SendThunder();
        }
        else if (distance <= 55 && distance >= 36)
        {
            SpawnObject(plant2Prefab);
            WizardLightning();
            SendThunder();
        }
        else if (distance <= 35)
        {
            SpawnObject(plant3Prefab);
            WizardLightning();
            SendThunder();
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
    void WizardLightning()
    {
        GameObject raio = Instantiate(Vfx, transform.position, transform.rotation);
        raio.SetActive(true);
        Destroy(raio, 1.00f);
    }

    void SendThunder()
    {
        Vector3 position = WhiteWizard.transform.position + new Vector3(0,40,0);
        Quaternion rot = Quaternion.Euler(90, 0, 0);
        Debug.Log(position);
        GameObject raio = Instantiate(Vfx, position, rot);
        raio.SetActive(true);
        Destroy(raio, 1.00f);
        
        
    }

}
