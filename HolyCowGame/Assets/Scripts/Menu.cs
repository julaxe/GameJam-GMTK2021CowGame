using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionMenu;
    public GameObject howToPlay;
    
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
