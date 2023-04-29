using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackWizardHealth : MonoBehaviour
{
    [SerializeField] public int blackWizardLife;
    public int currentBlackWizardHealth;



    // Start is called before the first frame update
    void Start()
    {
        currentBlackWizardHealth = blackWizardLife;
    }

    // Update is called once per frame
    void Update()
    {


    }

  



}
