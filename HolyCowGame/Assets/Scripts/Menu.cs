using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject optionMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void OptionMenu()
    {
        gameObject.SetActive(false);
        optionMenu.SetActive(true);
    }

    public void BackMainMenu()
    {
        gameObject.SetActive(true);
        optionMenu.SetActive(false);
    }
}
