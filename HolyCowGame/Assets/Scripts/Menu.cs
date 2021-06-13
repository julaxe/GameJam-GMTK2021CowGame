using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionMenu;
    public GameObject howToPlay;

    private float musicVolume;
    private void Start()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            musicVolume = PlayerPrefs.GetFloat("volume");
        }
        else
        {
            musicVolume = 1f;
        }

        AudioListener.volume = musicVolume;
    }
    private void Update()
    {
        
        
        
        
    }

    public void PlayGame()
    {        
       //SceneManager.LoadScene("");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        mainMenu.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void OptionMenu()
    {
        mainMenu.SetActive(false);
        optionMenu.SetActive(true);
    }

    public void VolumeChange(float volume)
    {
        musicVolume = volume;
        AudioListener.volume = musicVolume;
        PlayerPrefs.SetFloat("volume", musicVolume);
        Debug.Log(AudioListener.volume);
    }

    public void HowToPlay()
    {
        mainMenu.SetActive(false);
        howToPlay.SetActive(true);
    }
    public void BackMainMenu()
    {
        mainMenu.SetActive(true);
        optionMenu.SetActive(false);
    }
}
