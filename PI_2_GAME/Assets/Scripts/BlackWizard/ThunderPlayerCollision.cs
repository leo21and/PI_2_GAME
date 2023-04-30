using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderPlayerCollision : MonoBehaviour
{
    public PlayerDamage playerDamage;
    public int thunderDamage = 50;

    private void OnParticleCollision(GameObject other)
    {

        Debug.Log("Thunder Collider");
        playerDamage.currentHealth = playerDamage.currentHealth - thunderDamage;

    }
}
