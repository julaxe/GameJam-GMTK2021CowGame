using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "HolyCow")
        {
            Debug.Log("HolyCow in the Safe Zone!!!!");
            collision.gameObject.GetComponent<idleMovementHolyCow>().enabled = false;
            collision.gameObject.layer = 0;
        }
    }
    
}
