using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;


public class StartGameafterCS : MonoBehaviour
{
    [SerializeField] private GameObject fpcamera;
    [SerializeField] public PlayerController player;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private PlayableDirector director;
    [SerializeField] private GameObject cutscene;
    [SerializeField] private GameObject skip;
   

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
        }
        
    }
}
