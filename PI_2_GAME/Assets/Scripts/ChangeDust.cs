using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChangeDust : MonoBehaviour
{
    private FlowersToxic _flowersToxic;

    private ParticleSystem  dust;
    [SerializeField] private GameObject toxicDust;

    private bool startChange;
    
    // Start is called before the first frame update
    void Start()
    {
        _flowersToxic = GetComponent<FlowersToxic>();
        dust = GetComponentInChildren<ParticleSystem>();

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

        var main = dust.main;
        main.startColor = new Color(0, 255,192, 70);
        
        yield return new WaitForSeconds(5);
        
        toxicDust.SetActive(false);
        startChange = false;
    }
}
