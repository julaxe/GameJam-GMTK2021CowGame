using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HolyCowHealthCount : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int m_MaxHealth;
    private int m_CurrentHealth;
    private Animator animator;
    private HealthBarScript healthbar;
    private bool isDead = false;
    void Start()
    {
        animator = transform.GetComponent<Animator>();
        healthbar = transform.Find("CanvasHealth").Find("HealthBar").GetComponent<HealthBarScript>();
        healthbar.slider = transform.Find("CanvasHealth").Find("HealthBar").GetComponent<HealthBarScript>().GetComponent<Slider>();
        m_CurrentHealth = m_MaxHealth;
        healthbar.SetMaxHealth(m_MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(m_CurrentHealth <= 0 && !isDead)
        {            
            animator.SetTrigger("Dead");
            --GaneEvent.leftHolyCattle;
            isDead = true;
        }
    }

    public void TakeDamage(int damage)
    {
        m_CurrentHealth -= damage;
        healthbar.SetHealth(m_CurrentHealth);
    }
    private void Death()
    {
        Destroy(gameObject);
    }
}
