using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisintegrationController : MonoBehaviour
{
    [SerializeField] private BlackWizardScript bw;
    public SkinnedMeshRenderer meshRenderer;
    private Material _material;
    public float disintegrateRate = 0.0125f;
    public float refreshrate = 0.025f;

    public bool startDisintegrate;
        

    // Start is called before the first frame update
    void Start()
    {
        if (meshRenderer != null)
        {
            _material = meshRenderer.material;
        }

        startDisintegrate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startDisintegrate && bw.wizardDeath)
        {
            StartCoroutine(Disintegrate());
        }
    }

    IEnumerator Disintegrate()
    {
        startDisintegrate = true;
        float counter = 0;
        while (_material.GetFloat("_Weight") < 1)
        {
            counter += disintegrateRate;
            _material.SetFloat("_Weight", counter);
            yield return new WaitForSeconds(refreshrate);
        }

        startDisintegrate = false;
    }
}
