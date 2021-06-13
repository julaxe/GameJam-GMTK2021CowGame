using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    enum PlayerNumber
    {
        player1,
        player2
    }
    [SerializeField] private float m_Speed;
    [SerializeField] private PlayerNumber m_PlayerNumber;  

    private Rigidbody2D rb;
    private Vector2 m_currentForce;

    //animation
    private Animator animator;
    private bool m_moving;
    private bool m_facingRight;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.AddForce(m_currentForce);
    }
    // Update is called once per frame
    void Update()
    {
        //keys for player 1.
        if(m_PlayerNumber == PlayerNumber.player1)
        {
            if (Input.GetKey(KeyCode.W))
            {
                m_currentForce = Vector2.up * m_Speed;
            }
            if (Input.GetKey(KeyCode.A))
            {
                m_currentForce = Vector2.left * m_Speed;
                m_facingRight = false;
            }
            if (Input.GetKey(KeyCode.S))
            {
                m_currentForce = Vector2.down * m_Speed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                m_currentForce = Vector2.right * m_Speed;
                m_facingRight = true;
            }           
        }

        //keys for player 2
        else if(m_PlayerNumber == PlayerNumber.player2)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                m_currentForce = Vector2.up * m_Speed;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                m_currentForce = Vector2.left * m_Speed;
                m_facingRight = false;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                m_currentForce = Vector2.down * m_Speed;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                m_currentForce = Vector2.right * m_Speed;
                m_facingRight = true;
            }
        }

        //this apply for both cases
        if (!Input.anyKey)
        {
            m_currentForce = Vector2.zero;
            m_moving = false;
        }else
        {
            m_moving = true;
        }

        //Fliping the X axis depending on the key input
        if(m_facingRight)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        animator.SetBool("isMoving", m_moving);
    }
}
