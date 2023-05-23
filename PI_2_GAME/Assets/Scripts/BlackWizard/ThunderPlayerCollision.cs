using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderPlayerCollision : MonoBehaviour
{
    public PlayerDamage playerDamage;
    public int thunderDamage = 50;
    public GameObject Electric_Beams;

    private void OnParticleCollision(GameObject other)
    {
    
        Electric_Beams.SetActive(true);
        Debug.Log("Thunder Collider");
        playerDamage.currentHealth = playerDamage.currentHealth - thunderDamage;
        Invoke("Disable_Electric_Beams", 1);
        
    }

    void Disable_Electric_Beams()
    {
        Electric_Beams.SetActive(false);
    }
}
