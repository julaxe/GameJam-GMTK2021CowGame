using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaneEvent : MonoBehaviour
{
    // Text
    
    public Text howManyNeed;

    //Menu
    public GameObject menu;

    // Cow - Demon
    public static int totalAmountOfDemon;
    public static int amountOfDemon;
    // Cow - Holy
    public static int leftHolyCattle;
    public static int amountOfNeed;
    public static int storedCattle;
    // Start is called before the first frame update
    void Start()
    {
        totalAmountOfDemon = 5;
        amountOfNeed = 7;
        storedCattle = 0;
        howManyNeed.text = "Need :" + (amountOfNeed - storedCattle).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if((amountOfNeed - storedCattle) <= 0)
        {
            //Win State
        }

        if(Input.GetKeyUp(KeyCode.Escape))
        {
            menu.SetActive(true);
            Time.timeScale = 0f;
        }

        if(leftHolyCattle + storedCattle < amountOfNeed)
        {
            // Lose State
        }

    }
}
