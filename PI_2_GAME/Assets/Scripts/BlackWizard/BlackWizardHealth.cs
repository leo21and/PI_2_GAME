using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackWizardHealth : MonoBehaviour
{
    [SerializeField] public int blackWizardLife;
    public int currentBlackWizardHealth;

    [Header("Spell 2")]
    public int spell2Damage;
    Collisions collission;

    // Start is called before the first frame update
    void Start()
    {
        currentBlackWizardHealth = blackWizardLife;
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void BlackWizardSpell2Damage()
    {
        Debug.Log("Dano no Black Wizard com Spell 2");
        currentBlackWizardHealth = (currentBlackWizardHealth - spell2Damage);

    }
}
