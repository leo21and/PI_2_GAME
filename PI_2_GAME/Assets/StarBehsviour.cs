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
    // Start is called before the first frame update
    void Start()
    {
        _animais = GetComponent<Animais>();
        starsStart = false;
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
       // star.SetActive(true);
       star.SetActive(true);
        yield return new WaitForSeconds(fade);
        _particleSystem.Stop();
        starsStart = false;

    }
    
    
}
