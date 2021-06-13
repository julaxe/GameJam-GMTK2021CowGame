using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonCowDamage : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rope")
        {

            killCow();
        }

    }

    public void killCow()
    {
        --GaneEvent.amountOfDemon;
        Destroy(this.gameObject);        
    }
}