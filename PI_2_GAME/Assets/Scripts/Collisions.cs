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
    [SerializeField] private Transform castPoint;
    [SerializeField] public Spell[] spellToCast;

    //BlackWizard
    public BlackWizardScript BlackWizard;

    public TrailRenderer SpellTrail, Spell2Trail, Spell3Trail;
    RaycastHit hit;
    public FlyingEnemy[] flyingEnemy;

    public AudioClip spells1, spells2, spells3;
    public AudioSource audio;

    public void CastSpell()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {

            TrailRenderer trail = Instantiate(SpellTrail, castPoint.transform.position, Quaternion.identity);
            StartCoroutine(SpawnTrail1(trail, hit));

            //Dano no Inimigo voador
            //Precisa de correçao porque o raio do collider é muito grande
            //if (hit.collider.tag == "FlyingEnemy")
            //{
            //    for(int i = 0; i < flyingEnemy.Length; i++)
            //    {
            //        flyingEnemy[i].Damage();

            //    }


            //}
            audio.clip = spells1;
            audio.Play();

        }

        GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactGO, 2f);




    }

    public void CastSpell2()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {

            TrailRenderer trail = Instantiate(Spell2Trail, castPoint.transform.position, Quaternion.identity);
            StartCoroutine(SpawnTrail2(trail, hit));

            // Ataque ao Black Wizard
            if (hit.collider.tag == "BlackWizard")
            {
                
               BlackWizard.BlackWizardSpell2Damage();
           
            }
            audio.clip = spells2;
            audio.Play();
        }

        GameObject impactGO = Instantiate(impactEffect2, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactGO, 2f);

    }

    public void CastSpell3()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            TrailRenderer trail = Instantiate(Spell3Trail, castPoint.transform.position, Quaternion.identity);
            StartCoroutine(SpawnTrail3(trail, hit));

            audio.clip = spells3;
            audio.Play();
        }

        GameObject impactGO = Instantiate(impactEffect3, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactGO, 2f);
    }

    private IEnumerator SpawnTrail1(TrailRenderer trail, RaycastHit hit)
    {
        float time = 0;
        Vector3 startPosition = trail.transform.position;
        bool collidedWithAnimal = false;

        while (time < 1)
        {
            trail.transform.position = Vector3.Lerp(startPosition, hit.point, time);
            time += Time.deltaTime;

            // Check if the trail is colliding with an Animal
            Collider[] colliders = Physics.OverlapSphere(trail.transform.position, trail.startWidth / 2f);

            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Animais") && collider.GetComponent<Animais>().animalSaved == false)
                {
                    collidedWithAnimal = true;
                    collider.GetComponent<Animais>().animalSaved = true;
                    countAnimais++;
                    CurrentLevel();
                    AnimalCollected.SetActive(true);
                    isWaitingA = true;
                }
            }

            if (collidedWithAnimal)
            {
                break;
            }

            yield return null;
        }

        trail.transform.position = hit.point;
        Destroy(trail.gameObject, trail.time);
    }

    private IEnumerator SpawnTrail2(TrailRenderer trail, RaycastHit hit)
    {
        float time = 0;
        Vector3 startPosition = trail.transform.position;
        bool collidedWithSilva = false;

        while (time < 1)
        {
            trail.transform.position = Vector3.Lerp(startPosition, hit.point, time);
            time += Time.deltaTime;

            // Check if the trail is colliding with a Silva
            Collider[] colliders = Physics.OverlapSphere(trail.transform.position, trail.startWidth / 2f);

            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Silvas") && collider.GetComponent<Silvas>().silvaClean == false)
                {
                    collidedWithSilva = true;
                    collider.GetComponent<Silvas>().silvaClean = true;
                    countSilvas++;
                    CurrentLevel();
                    SilvaCollected.SetActive(true);
                    isWaitingS = true;
                }
            }

            if (collidedWithSilva)
            {
                break;
            }

            yield return null;
        }

        trail.transform.position = hit.point;
        Destroy(trail.gameObject, trail.time);
    }

    private IEnumerator SpawnTrail3(TrailRenderer trail, RaycastHit hit)
    {
        float time = 0;
        Vector3 startPosition = trail.transform.position;
        bool collidedWithFlower = false;

        while (time < 1)
        {
            trail.transform.position = Vector3.Lerp(startPosition, hit.point, time);
            time += Time.deltaTime;

            // Check if the trail is colliding with a FlowersToxic
            Collider[] colliders = Physics.OverlapSphere(trail.transform.position, trail.startWidth / 2f);

            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Toxic") && collider.GetComponent<FlowersToxic>().flowerHeal == false)
                {
                    collidedWithFlower = true;
                    collider.GetComponent<FlowersToxic>().flowerHeal = true;
                    countF++;
                    CurrentLevel();
                    FlowerCollected.SetActive(true);
                    isWaitingF = true;
                }
            }

            if (collidedWithFlower)
            {
                break;
            }

            yield return null;
        }

        trail.transform.position = hit.point;
        Destroy(trail.gameObject, trail.time);
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
            flower_text.text = countF.ToString() + "/20";
            animal_text.text = countAnimais.ToString() + "/10";
            silva_text.text = countSilvas.ToString() + "/10";
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
