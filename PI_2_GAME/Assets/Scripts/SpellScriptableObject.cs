using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Spell", menuName = "Spells")]
public class SpellScriptableObject : ScriptableObject
{
    public float DamageAmount = 10f;
    public float PowerCost = 5f;
    public float Lifetime = 1f;
    public float Speed = 1000f;
    public float SpellRadius = 0.5f;
}
