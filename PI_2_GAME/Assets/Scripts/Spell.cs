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

    // Update is called once per frame
    void Update()
    {

        if (SpellToCast.Speed > 0)
        {
            transform.Translate(transform.forward * SpellToCast.Speed * Time.deltaTime);

        }
    }

}
