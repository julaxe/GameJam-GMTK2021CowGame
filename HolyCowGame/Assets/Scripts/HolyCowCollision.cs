using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyCowCollision : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator animator;
    [SerializeField] float forceAmount = 5;

    private float nextAttackTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        ++GaneEvent.leftHolyCattle;
        animator = transform.GetComponent<Animator>();
        body = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", body.velocity.magnitude);        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "DemonCow")
        {
            nextAttackTime = Time.time + 2.0f; //next attack is in 2 seconds.
            SoundManagerScript.PlaySound("holyCowHit");
            this.GetComponent<HolyCowHealthCount>().TakeDamage(20);
            ContactPoint2D contact = collision.contacts[0];
            /*Vector2 temp = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            temp = temp.normalized;*/
            Vector2 temp = contact.normal * 0.5f;
            body.AddForce((temp * forceAmount), ForceMode2D.Impulse);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce((temp * forceAmount), ForceMode2D.Impulse);
            collision.gameObject.GetComponent<DemonCowAgentMoving>().demonCowChangingState(0);
        }
        if(collision.gameObject.tag == "SafeZone")
        {
            gameObject.tag = "Untagged";
            gameObject.layer = 0;
            --GaneEvent.leftHolyCattle;
            Debug.Log("One Point");
        }
        if (collision.gameObject.layer == 9)
        {
            ContactPoint2D contactPoint2D = collision.contacts[0];
            Vector2 temp;
            if (gameObject.transform.position.y >= 0)
            {
                temp = contactPoint2D.normal * 0.5f * Vector2.down;
            }
            else
            {
                temp = contactPoint2D.normal * 0.5f * Vector2.up;
            }

            body.AddForce((temp * forceAmount), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DemonCow" && Time.time > nextAttackTime)
        {
            nextAttackTime = Time.time + 2.0f; //next attack is in 2 seconds.
            SoundManagerScript.PlaySound("holyCowHit");
            this.GetComponent<HolyCowHealthCount>().TakeDamage(20);
        }
    }

}
