using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaneEvent : MonoBehaviour
{
    // Text
    private Text leftCattle;
    private Text howManyNeed;

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
        leftCattle = transform.FindChild("leftCattle").GetComponent<Text>();
        howManyNeed = transform.FindChild("howManyNeed").GetComponent<Text>();
        storedCattle = 0;
        leftCattle.text = "aaa";
        howManyNeed.text = "bbb";
    }

    // Update is called once per frame
    void Update()
    {


        if(leftHolyCattle + storedCattle < amountOfNeed)
        {
            // Lose State
        }

    }
}
