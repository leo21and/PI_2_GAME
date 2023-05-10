using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class RestartAfterCut : MonoBehaviour
{
    [SerializeField] private GameObject fpcamera;
    [SerializeField] public PlayerController player;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private PlayableDirector director;
    [SerializeField] private GameObject cutscene;
    
    [SerializeField] private GameObject trigger;

    [SerializeField] private CutSceneActivate csa;
    
   

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("entrourourou");
      
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
        OnEndCutScene();

        if (csa.disable)
        {
            player.OnDisable();
        
            fpcamera.SetActive(false);
            _characterController.enabled = false;
            
            player.canCastSpell = false;
            

        }
    }

    void OnEndCutScene()
    {
        if (director.state != PlayState.Playing)
        {
            csa.disable = false;
            Debug.Log("entrou?");
            cutscene.SetActive(false);
            fpcamera.SetActive(true);
            player.OnEnable();
            _characterController.enabled = true;
            
            
            trigger.SetActive(false); 
            player.canCastSpell = true;
            Debug.Log(player.canCastSpell);

        }
        
    }
}
