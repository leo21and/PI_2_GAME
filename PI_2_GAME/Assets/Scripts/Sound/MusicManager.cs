using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioMixer sfxMixer;

    [Header("Black Wizard Attacks")]
    [SerializeField] AudioSource Thunder;
    [SerializeField] AudioSource Laser;
    [SerializeField] AudioSource SerpentSpell;

    [Header("Black Wizard Sounds")]
    [SerializeField] AudioSource Hurt;
    [SerializeField] AudioSource Death;


    public void SendThunderSFX()
    {
        Thunder.Play();

    }

    public void BWSerpentSpell()
    {
        SerpentSpell.Play();

    }
    public void BWHurt()
    {
        Hurt.Play();

    }

    public void BWLaser()
    {
        Laser.Play();

    }
    public void BWDeath()
    {
        Death.Play();

    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
