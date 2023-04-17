using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    private PlayerInput _playerInput;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerInput = new PlayerInput();
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
        _playerInput.Player.Enable();
        _playerInput.Powers.Enable();
        _playerInput.PAUSE.Enable();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      

    }

    public void Exit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
