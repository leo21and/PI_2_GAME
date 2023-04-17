using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{

    public bool gamePaused = false;

    public GameObject pauseMenuUI;
    private PlayerInput _playerInput;
    public GameObject settings;
   // public GameObject initial;
    
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
    }
}
