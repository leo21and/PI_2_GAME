using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateField : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject field;
    [SerializeField] private Animator _animator1;
    [SerializeField] private Animator _animator2;
    [SerializeField] private Animator _animator3;
    [SerializeField] private Animator _animator4;
    [SerializeField] private Animator _animator5;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioSource _audioSource2;
    private bool oneplay;


    void Start()
    {
        oneplay = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "fonte")
        {
           StartCoroutine(fieldActivate());
        }
    }

    IEnumerator fieldActivate()
    {
        field.SetActive(true);

        if (oneplay)
        {
            _audioSource.Play();
            oneplay = false; //para so tocar uma vez
        }
        
        yield return new WaitForSeconds(12);
        _audioSource2.Play();
        _animator1.SetTrigger("Change");
        _animator2.SetTrigger("Change");
        _animator3.SetTrigger("Change");
        _animator4.SetTrigger("Change");
        _animator5.SetTrigger("Change");

        yield return new WaitForSeconds(3.5f);
        field.SetActive(false); 
        _audioSource2.Stop();
        oneplay = true;
    }
}
