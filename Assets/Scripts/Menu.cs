using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;
using System.Linq;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    /// <summary>
    /// This class handles all functions in the main menu and pause menu.
    /// </summary>
    /// 

    public AudioMixer mixer;
    Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;
    public GameObject optionsMenu;
    public GameObject pauseFirstButton, optionsFirstButton, optionsClosedButton;
 

    void Start()
    {
        resolutions = Screen.resolutions.Select(Resolution => new Resolution { width = Resolution.width, height = Resolution.height }).Distinct().ToArray();    //Update resolution to chosen resolution

  
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)    //Create a list of all possible resolutions
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width &&  resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i; 
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void PlayGame()
    {
        Debug.Log("Play Game Button Pressed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OpenOptions()
    {
        optionsMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null); //Clear selected object for controller input
        EventSystem.current.SetSelectedGameObject(optionsFirstButton); //Set new selected object
    }

    public void CloseOptions()
    {
        optionsMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionsClosedButton);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void LoadMainMenu() 
    {
        SceneManager.LoadScene(0);  // First scene in build settings --> main menu
    }

    public void ChangeVolume(float level)   //Volume slider setting
    {
        mixer.SetFloat("Volume", level);
    }

    public void SetResolution(int resolutionIndex) //Resolutions setting
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void ChangeGraphicsQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen (bool isFullscreen)   // Fullscreen setting
    {
        Screen.fullScreen = isFullscreen;
    }

}
