using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class Spell : MonoBehaviour
{

    public SpellScriptableObject SpellToCast;




    private void Awake()
    {


        Destroy(this.gameObject, SpellToCast.Lifetime);
    }


}
