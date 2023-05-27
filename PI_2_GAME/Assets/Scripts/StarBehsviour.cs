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

    [SerializeField] private Animator rabbit;

    public bool trigou;

    
    // Start is called before the first frame update
    void Start()
    {
        _animais = GetComponent<Animais>();
        starsStart = false;
        starmat = GetComponentInChildren<ParticleSystemRenderer>().material;
        trigou = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!starsStart && _animais.animalSaved)
        {
            
            StartCoroutine(FadeOut());

            if (!trigou)
            {

                StartCoroutine(Anim());
            }
          
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

    IEnumerator Anim()
    {
        rabbit.SetTrigger("heal");

        yield return new WaitForSeconds(3);
        trigou = true;
    }
    
    
}
