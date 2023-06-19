using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantsPlayerCollision : MonoBehaviour
{
    public PlayerDamage playerDamage;
    public int PlantDamage = 25;
    public float damageInterval = 5f;
    private float timer = 0f;

    private void Start()
    {
        playerDamage = FindAnyObjectByType<PlayerDamage>();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            
                // Apply damage
                playerDamage.TakeDamage(PlantDamage);

 
        }
    }

    void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            // Increment the timer
            timer += Time.deltaTime;

            // Check if the specified time interval has passed
            if (timer >= damageInterval)
            {
                // Apply damage
                playerDamage.TakeDamage(PlantDamage);

                // Reset the timer
                timer = 0f;
            }
        }
    }

    void Update()
    {
        int i = 0;
    }
 }
