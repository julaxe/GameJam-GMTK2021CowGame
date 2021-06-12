using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyCowCollision : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] float forceAmount = 5;
    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "DemonCow")
        {
            this.GetComponent<HolyCowHealthCount>().TakeDamage(20);

            Vector2 temp = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            temp = temp.normalized;
            body.AddForce(temp * forceAmount, ForceMode2D.Impulse);
            collision.gameObject.GetComponent<DemonCowAgentMoving>().demonCowChangingState(0);
        }
        if(collision.gameObject.tag == "SafeZone")
        {
            //add ui update
            Debug.Log("One Point");
        }
    }

}
