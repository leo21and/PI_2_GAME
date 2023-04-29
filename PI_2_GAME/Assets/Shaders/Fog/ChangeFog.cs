using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFog : MonoBehaviour
{
    [SerializeField] private PlayerController pc;

    private bool startchange;

    private ParticleSystem ps;
    private ParticleSystem.MainModule main;
    private Material fogmat;

    
    // Start is called before the first frame update
    void Start()
    {
        //ps = GetComponent<ParticleSystem>();
        startchange = false;
        
        // ps = GetComponent<ParticleSystem>();
        // main = ps.main;
        fogmat = GetComponent<ParticleSystemRenderer>().material;
       
            

    }

    // Update is called once per frame
    void Update()
    {
        if (!startchange && pc.zona != 0)
        {
            StartCoroutine(changeFog());
        }
    }

    IEnumerator changeFog()
    {
        startchange = true;
        
        
        switch (pc.zona)
        {
            case 2:
                fogmat.SetColor("_TintColor", new Color32(217, 156, 212, 15));
                break;
            case 3:
                fogmat.SetColor("_TintColor", new Color32(217, 156, 212, 12));
                break;
            case 4:
                fogmat.SetColor("_TintColor", new Color32(217, 156, 212, 10));
                break;
            case 5:
                fogmat.SetColor("_TintColor", new Color32(217, 156, 212, 5));
                break;
            default:
                Debug.Log("none");
                break;
        }

        yield return new WaitForSeconds(2);
        startchange = false;

    }
}
