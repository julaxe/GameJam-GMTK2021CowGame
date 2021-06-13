using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GaneEvent : MonoBehaviour
{
    // Text
    
    public Text howManyNeed;

    //Menu
    public GameObject menu;
    [SerializeField]
    private int level;

    // Cow - Demon
    public static int totalAmountOfDemon;
    public static int amountOfDemon;
    [SerializeField]
    private int demonCattleAmount;
    // Cow - Holy
    public static int leftHolyCattle;
    public static int amountOfNeed;
    public static int storedCattle;
    [SerializeField]
    private int cattleNeedAmount;
    

    // Start is called before the first frame update
    void Start()
    {
        amountOfNeed = cattleNeedAmount;
        totalAmountOfDemon = demonCattleAmount;        
        storedCattle = 0;
        howManyNeed.text = "Need :" + (amountOfNeed - storedCattle).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if((amountOfNeed - storedCattle) <= 0)
        {
            SceneManager.LoadScene(level);
        }

        if(Input.GetKeyUp(KeyCode.Escape))
        {
            menu.SetActive(true);
            Time.timeScale = 0f;
        }

        if(leftHolyCattle + storedCattle < amountOfNeed)
        {
            SceneManager.LoadScene(0);
        }

    }
}
