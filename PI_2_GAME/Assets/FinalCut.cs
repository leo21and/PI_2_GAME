using System.Collections;
using System.Collections.Generic;
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
        //     if (bs.startCutFinal == true)
        //     {
        //         Debug.Log("entra cut final");
        //         pc.OnDisable();
        //     
        //         fpcamera.SetActive(false);
        //         cc.enabled = false;
        //         
        //         cutFinal.SetActive(true);
        //
        //         if (director.state != PlayState.Playing)
        //         {
        //             gameOverMenu.SetActive(true);
        //         }
        //     }
        // }
    }
}
