using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveController : MonoBehaviour
{

    public MeshRenderer meshRenderer; //substituir possivelmente por skinnedMesh

    private Material[] material;

    public float dissolveRate = 0.0125f;

    public float refreshRate = 0.025f;
    // Start is called before the first frame update
    void Start()
    {
        if (meshRenderer != null)
        {
            material = meshRenderer.materials;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Quando se desfazer
        if (Input.GetKeyUp(KeyCode.G))
        {
            StartCoroutine(Dissolve());
        }
    }

    IEnumerator Dissolve()
    {
        if (material.Length > 0)
        {
            float counter = 0;
            while (material[0].GetFloat("_DissolveAmount") < 1)
            {
                counter += dissolveRate;
                for (int i = 0; i < material.Length; i++)
                {
                    material[i].SetFloat("_DissolveAmount", counter);
                }

                yield return new WaitForSeconds(refreshRate);
            }
        }
    }
}
