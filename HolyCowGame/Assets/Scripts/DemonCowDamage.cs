using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonCowDamage : MonoBehaviour
{
    Animator animator;
    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        animator = transform.GetComponent<Animator>();
        animator.SetTrigger("Spawn");
    }

    // Update is called once per frame
    void Update()
    {

    }

  /*  private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rope")
        {

            //killCow();
        }

    }

    public void killCow()
    {        
        animator.SetTrigger("Death");
        --GaneEvent.amountOfDemon;
        isDead = true;        
    }*/
    
}