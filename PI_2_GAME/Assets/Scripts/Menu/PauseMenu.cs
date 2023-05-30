using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{

    public bool gamePaused = false;

    public GameObject pauseMenuUI;
    private PlayerInput _playerInput;
    public GameObject settings, mira, currentPowerUI;
   // public GameObject initial;
   [SerializeField] private AudioMixerGroup effects;
   [SerializeField] private AudioSource maintheme;
   [SerializeField] private AudioSource bossMusic;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerInput = new PlayerInput();
        _playerInput.PAUSE.Enable();
        _playerInput.PAUSE.pause.performed += ShowUI;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenuUI.activeSelf || settings.activeSelf)
        {
            effects.audioMixer.SetFloat("VolumeEffects", -80f);

            if (maintheme.isPlaying)
            {
                maintheme.volume = 0.5f; 
            }
            else if (bossMusic.isPlaying)
            {
                bossMusic.volume = 0.5f;
            }
            

        }
        else
        {
            effects.audioMixer.SetFloat("VolumeEffects", 0f);

            if (maintheme.isPlaying)
            {
                maintheme.volume = 0.05f; //mudar se for preciso ajustar o som 
            }
            else if (bossMusic.isPlaying)
            {
                bossMusic.volume = 0.2f;
            }
          
        }
    }

    public void ShowUI(InputAction.CallbackContext context)
    {
        if (gamePaused)
        {
            Resume();
        }
        else
        {
            _playerInput.Disable();
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            gamePaused = true;
            mira.SetActive(false);
            currentPowerUI.SetActive(false);
        }
    }

    public void Resume()
    {
        _playerInput.Enable();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
        
        Debug.Log("clicked");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowSettings()
    {
        settings.SetActive(true);
        pauseMenuUI.SetActive(false);
        mira.SetActive(false);
        currentPowerUI.SetActive(false);

    }
}
