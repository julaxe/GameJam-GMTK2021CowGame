using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    private Animator animator;
    private bool m_isMoving = false;

    private Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //is moving
        if(rb.velocity == Vector2.zero)
        {
            m_isMoving = false;
        }
        else
        {
            m_isMoving = true;
        }

        animator.SetBool("isMoving", m_isMoving);

        
    }
}
