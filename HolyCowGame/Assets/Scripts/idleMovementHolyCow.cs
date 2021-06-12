using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleMovementHolyCow : MonoBehaviour
{
    [SerializeField] private float nextMovement = 0.0f;
    [SerializeField] private float amountForce = 1;
    [SerializeField] private float minTime = 1.0f;
    [SerializeField] private float maxTime = 6.0f;
    private Rigidbody2D body;
    
    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        nextMovement = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(body.velocity == Vector2.zero && Time.time > nextMovement)
        {
            Vector2 temp = new Vector2(Random.Range(-100.0f, 100.0f), Random.Range(-100.0f, 100.0f));
            temp = temp.normalized;
            nextMovement = Time.time + Random.Range(minTime, maxTime);
            body.AddForce( temp * amountForce, ForceMode2D.Impulse);

        }
    }
}
