using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.Audio;


public class StartGameafterCS : MonoBehaviour
{
    [SerializeField] private GameObject fpcamera;
    [SerializeField] public PlayerController player;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private PlayableDirector director;
    [SerializeField] private GameObject cutscene;
    [SerializeField] private GameObject skip;
    public AudioMixerGroup effects;
    public AudioSource mainTheme;
   
   

    // Start is called before the first frame update
    void Start()
    {
        player.OnDisable();
        
       fpcamera.SetActive(false);
       _characterController.enabled = false;
       skip.SetActive(true);
       
    }

    // Update is called once per frame
    void Update()
    {
        Stopall();
        player.canCastSpell = false;
        OnEndCutScene();
    }

    void OnEndCutScene()
    {
        if (director.state != PlayState.Playing)
        {
            cutscene.SetActive(false);
            fpcamera.SetActive(true);
            player.OnEnable();
            _characterController.enabled = true;
            skip.SetActive(false);
            player.canCastSpell = true;
            this.gameObject.SetActive(false);
            effects.audioMixer.SetFloat("VolumeEffects", 0);
            mainTheme.volume = 0.05f; //mudar se necessário 
        }
        
    }

    void Stopall()
    {
        mainTheme.volume = 0.5f;
        effects.audioMixer.SetFloat("VolumeEffects",-80f);
    }
}
