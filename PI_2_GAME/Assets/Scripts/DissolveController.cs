using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveController : MonoBehaviour
{

    public SkinnedMeshRenderer meshRenderer; //substituir possivelmente por skinnedMesh

    private Material material;

    public float dissolveRate = 0.0125f; //0.0125;

    public float refreshRate = 0.025f; //0.025

    [SerializeField] private Silvas silvas;
    [SerializeField] private AudioSource AudioSilvas;

    public bool dissolve;
    // Start is called before the first frame update
    void Start()
    {
        if (meshRenderer != null)
        {
            material = meshRenderer.material;
        }

        dissolve = false;
        // silvas = GetComponentInChildren<Silvas>();
        // Identificar o Audio Source da Silva
        AudioSilvas = silvas.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //Quando se desfazer
        if (!dissolve && silvas.silvaClean)
        { 
            StartCoroutine(Dissolve());
        }
    }
    
    IEnumerator Dissolve()
    {
        dissolve = true;

        // Desligar o som da Silva
        AudioSilvas.loop = false;

        float counter = 0;
        while (material.GetFloat("_DissolveAmount") < 1)
        {
            counter += dissolveRate;
            
            material.SetFloat("_DissolveAmount", counter);
                    
            yield return new WaitForSeconds(refreshRate);
           
        }
        this.gameObject.SetActive(false); 
       
        
        dissolve = false;
    }


}

   

