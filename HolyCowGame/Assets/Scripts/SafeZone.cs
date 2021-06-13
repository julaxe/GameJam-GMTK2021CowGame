using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "HolyCow")
        {
            GaneEvent.amountOfNeed -= 1;
            GaneEvent.leftHolyCattle -= 1;
            Debug.Log("HolyCow in the Safe Zone!!!!");
            SoundManagerScript.PlaySound("holyCowCollected");
            collision.gameObject.GetComponent<idleMovementHolyCow>().enabled = false;
            collision.gameObject.layer = 0;            
        }
    }
    
}
