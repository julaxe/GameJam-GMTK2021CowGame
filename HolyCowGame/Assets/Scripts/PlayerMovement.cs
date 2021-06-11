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
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_PlayerNumber == PlayerNumber.player1)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(Vector2.up * m_Speed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(Vector2.left * m_Speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(Vector2.down * m_Speed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(Vector2.right * m_Speed);
            }
        }
        else if(m_PlayerNumber == PlayerNumber.player2)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.AddForce(Vector2.up * m_Speed);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddForce(Vector2.left * m_Speed);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.AddForce(Vector2.down * m_Speed);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.AddForce(Vector2.right * m_Speed);
            }
        }    
    }
}
