using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ChangeCloud : MonoBehaviour
{
    [SerializeField] private PlayerController pc;

    private bool startchange;

    private ParticleSystem ps;
    private ParticleSystem.MainModule main;
    private Material cloudmat;

    
    // Start is called before the first frame update
    void Start()
    {
        //ps = GetComponent<ParticleSystem>();
        startchange = false;
        
       // ps = GetComponent<ParticleSystem>();
       // main = ps.main;
        cloudmat = GetComponent<ParticleSystemRenderer>().material;
       
            

    }

    // Update is called once per frame
    void Update()
    {
        if (!startchange && pc.zona != 0)
        {
            StartCoroutine(changeCloud());
        }
    }

    IEnumerator changeCloud()
    {
        startchange = true;
        
        
        switch (pc.zona)
        {
            case 2:
                cloudmat.SetColor("_TintColor", new Color32(203, 139, 212, 40));
                break;
            case 3:
                cloudmat.SetColor("_TintColor", new Color32(203, 139, 212, 20));
                break;
            case 4:
                cloudmat.SetColor("_TintColor", new Color32(203, 139, 212, 10));
                break;
            case 5:
                cloudmat.SetColor("_TintColor", new Color32(203, 139, 212, 5));
                break;
            default:
                Debug.Log("none");
                break;
        }

        yield return new WaitForSeconds(2);
        startchange = false;

    }
}
