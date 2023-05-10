using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.Playables;

public class FinalCut : MonoBehaviour
{
    [SerializeField] private BlackWizardScript bs;

    [SerializeField] private CharacterController cc;

    [SerializeField] private GameObject cutFinal;
    [SerializeField] private PlayerController pc;
    [SerializeField] private PlayableDirector director;
    [SerializeField] private GameObject fpcamera;
    [SerializeField] private GameObject gameOverMenu;

    // Start is called before the first frame update
    void Start()
    {
       
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bs.isDeath)
        {
            Debug.Log(bs.isDeath);
            
            pc.OnDisable();
            cc.enabled = false;
            fpcamera.SetActive(false);
           
        }
        
        OnEndCutScene();
        pc.canCastSpell = false;
    }

    void OnEndCutScene()
    {
        if (director.state != PlayState.Playing)
        {
            cutFinal.SetActive(false);
            gameOverMenu.SetActive(true);
          
        }
    }
}

