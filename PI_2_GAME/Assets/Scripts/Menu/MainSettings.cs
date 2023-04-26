using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainSettings : MonoBehaviour
{
    private Resolution[] _resolutions;
    public TMPro.TMP_Dropdown resolutionDropdown;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private FPCamera cam; 



    // Start is called before the first frame update
    void Start()
    {
       _resolutions = Screen.resolutions;
       
       resolutionDropdown.ClearOptions();

       List<string> options = new List<string>();

       int currentResolutionIndex = 0;

       for (int i = 0; i < _resolutions.Length; i++)
       {
           string option = _resolutions[i].width + "x" + _resolutions[i].height;
           options.Add(option);

           if (_resolutions[i].width == Screen.currentResolution.width &&
               _resolutions[i].height == Screen.currentResolution.height)
           {
               currentResolutionIndex = i;
           }
       }

       resolutionDropdown.AddOptions(options);
       resolutionDropdown.value = currentResolutionIndex;
       resolutionDropdown.RefreshShownValue();
    }

    public void SetSensivity()
    {
        

    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void OnExit()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void SetSensivity(float sensivityNew)
    {
        cam.sensivity = sensivityNew;
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
