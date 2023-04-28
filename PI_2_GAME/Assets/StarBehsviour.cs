using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBehsviour : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSystem;
    [SerializeField] private GameObject star;

    private float fade = 10.0f;

    private Animais _animais;

    private bool starsStart;

    private Material starmat;

    
    // Start is called before the first frame update
    void Start()
    {
        _animais = GetComponent<Animais>();
        starsStart = false;
        starmat = GetComponentInChildren<ParticleSystemRenderer>().material;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!starsStart && _animais.animalSaved)
        {
            
            StartCoroutine(FadeOut());
        }
    }
    
   

    IEnumerator FadeOut()
    {
        starsStart = true;

        var lightON = _particleSystem.lights;

        lightON.enabled = true;
        
        
        starmat .SetColor("_TintColor", new Color32(255,224,0, 255));
        yield return new WaitForSeconds(fade);
        _particleSystem.Stop();
        starsStart = false;

    }
    
    
}
