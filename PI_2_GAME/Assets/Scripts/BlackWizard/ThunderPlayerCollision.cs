using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderPlayerCollision : MonoBehaviour
{
    public PlayerDamage playerDamage;

    private void OnParticleCollision(GameObject other)
    {

        //playerDamage.currentHealth
        //StartCoroutine(TakeLife());
        Debug.Log("Thunder Collider");
        
    }
}
