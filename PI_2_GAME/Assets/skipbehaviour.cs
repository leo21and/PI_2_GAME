using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class skipbehaviour : MonoBehaviour
{
    
    [SerializeField] private GameObject fpcamera;
    [SerializeField] public PlayerController player;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private GameObject cutscene;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Skip()
    {
        cutscene.SetActive(false);
        fpcamera.SetActive(true);
        player.OnEnable();
        _characterController.enabled = true;
    }
}
