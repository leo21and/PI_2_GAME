using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChangeDust : MonoBehaviour
{
    private FlowersToxic _flowersToxic;

    private ParticleSystem  dust;
    [SerializeField] private GameObject toxicDust;
    private Material dustmat;

    private bool startChange;

    [SerializeField] private GameObject FlowerToxic;
    [SerializeField] private GameObject FlowerHeal;
    [SerializeField] private Animator FT;
    [SerializeField] private Animator FH;
    
    // Start is called before the first frame update
    void Start()
    {
        _flowersToxic = GetComponent<FlowersToxic>();
        dust = GetComponentInChildren<ParticleSystem>();
        dustmat = GetComponentInChildren<ParticleSystemRenderer>().material;

        startChange = false;
       
    }

    // Update is called once per frame
    void Update()
    {
  
        if (!startChange && _flowersToxic.flowerHeal)
        {
            
            StartCoroutine(DustHeal());
        }
    }

    IEnumerator DustHeal()
    { 
        startChange = true;
      //  dust.startColor = new Color(255, 192,0);
       
        var colorOverTime = dust.colorOverLifetime;
       
       colorOverTime.enabled = false; 

        dustmat.SetColor("_TintColor", new Color32 (0, 255, 142, 50));
        FT.SetTrigger("Scale");
        yield return new WaitForSeconds(1f);
      
        FlowerHeal.SetActive(true);
        FH.SetTrigger("Heal");
        
        yield return new WaitForSeconds(1f);
        dust.Stop();
        startChange = false;
        
       // yield return new WaitForSeconds(1f);
        FlowerToxic.SetActive(false);
        
    }
}
