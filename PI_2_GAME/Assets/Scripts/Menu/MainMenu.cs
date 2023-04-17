using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsMenu;
    
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        settingsMenu.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Settings()
    {
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
}
