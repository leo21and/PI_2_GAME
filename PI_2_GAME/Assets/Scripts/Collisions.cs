using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms;


public class Collisions : MonoBehaviour
{
    public List<GameObject> Animals = new List<GameObject>();
    public List<GameObject> Silvas = new List<GameObject>();

    public int countAnimais;
    public int countSilvas;
    public int countF;

    public GameObject AnimalCollected;
    public GameObject SilvaCollected;
    public GameObject FlowerCollected;

    private bool isWaitingF;
    private bool isWaitingA;
    private bool isWaitingS;
    
    private float timer = 0.7f;
    
    
    [SerializeField] private TMP_Text flower_text;
    [SerializeField] private TMP_Text animal_text;
    [SerializeField] private TMP_Text silva_text;

    public Camera cam;
    public float range = 100f;
    public float impactForce = 30f;
    public GameObject impactEffect, impactEffect2, impactEffect3;

    [SerializeField] private Spell spellToCast;
    [SerializeField] private Transform castPoint;

    public void CastSpell()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {

            //Instantiate(spellToCast, castPoint.position, castPoint.rotation);

            if (hit.collider.gameObject.tag == "Animais" && hit.collider.GetComponent<Animais>().animalSaved == false)
            {
                hit.collider.GetComponent<Animais>().animalSaved = true;
                countAnimais++;
                CurrentLevel();
                AnimalCollected.SetActive(true);
                isWaitingA = true;
            }

            
        }

        if (hit.rigidbody != null)
        {
            hit.rigidbody.AddForce(-hit.normal * impactForce);
        }

        GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactGO, 2f);

    }

    public void CastSpell2()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {

            //Instantiate(spellToCast, castPoint.position, castPoint.rotation);

            if (hit.collider.gameObject.tag == "Silvas" && hit.collider.GetComponent<Silvas>().silvaClean == false)
            {
                hit.collider.GetComponent<Silvas>().silvaClean = true;
                countSilvas++;
                CurrentLevel();
                SilvaCollected.SetActive(true);
                isWaitingS = true;
            }


        }

        if (hit.rigidbody != null)
        {
            hit.rigidbody.AddForce(-hit.normal * impactForce);
        }

        GameObject impactGO = Instantiate(impactEffect2, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactGO, 2f);

    }

    public void CastSpell3()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {

            //Instantiate(spellToCast, castPoint.position, castPoint.rotation);

            if (hit.collider.gameObject.tag == "Toxic" && hit.collider.GetComponent<FlowersToxic>().flowerHeal == false)
            {
                hit.collider.GetComponent<FlowersToxic>().flowerHeal = true;
                countF++;
                CurrentLevel();
                FlowerCollected.SetActive(true);
                isWaitingF = true;
            }


        }

        if (hit.rigidbody != null)
        {
            hit.rigidbody.AddForce(-hit.normal * impactForce);
        }

        GameObject impactGO = Instantiate(impactEffect3, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactGO, 2f);

    }

    public void CurrentLevel()
    {
        if (GameObject.Find("FirstLock") != null)
        {
            flower_text.text = countF.ToString() + "/1";
            animal_text.text = countAnimais.ToString() + "/1";
            silva_text.text = countSilvas.ToString() + "/1";

            Debug.Log("entrou aqui");
        }
        else if (GameObject.Find("SecondLock") != null)
        {
            flower_text.text = countF.ToString() + "/5";
            animal_text.text = countAnimais.ToString() + "/3";
            silva_text.text = countSilvas.ToString() + "/3";
        }
        else if (GameObject.Find("ThirdLock") != null)
        {
            flower_text.text = countF.ToString() + "/14";
            animal_text.text = countAnimais.ToString() + "/6";
            silva_text.text = countSilvas.ToString() + "/6";
        }
        else if (GameObject.Find("FourthLock") != null)
        {
            flower_text.text = countF.ToString() + "/24";
            animal_text.text = countAnimais.ToString() + "/1";
            silva_text.text = countSilvas.ToString() + "/1";
        }

    }

    private void Update()
    {
        if (isWaitingA)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                AnimalCollected.SetActive(false);
                isWaitingA = false;
                timer = 0.7f;
            }
        }
        else if (isWaitingF)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                FlowerCollected.SetActive(false);
                isWaitingF = false;
                timer = 0.7f;
            }
        } 
        else if (isWaitingS)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                SilvaCollected.SetActive(false);
                isWaitingS = false;
                timer = 0.7f;
            }
        } 
    }
    
    


    
}
