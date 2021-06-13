using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class DemonCowAgentMoving : MonoBehaviour
{
    private Animator animator;
    private GameObject[] holyCows;
    [SerializeField] Transform target;
    private NavMeshAgent agent;
    [SerializeField] private float coolAfterAttack = 2.0f;
    private float nextAttack = 0.0f;
    public enum demonCowStates { afterAttack, seeking};
    private demonCowStates demonCowCurrentState;

    private bool m_facingRight;

    // Start is called before the first frame update
    void Start()
    {
        animator = transform.GetComponent<Animator>();
        ++GaneEvent.amountOfDemon;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = agent.updateUpAxis = false;
        if (target == null)
        {            
            holyCows = GameObject.FindGameObjectsWithTag("HolyCow");
            target = holyCows[0].GetComponent<Transform>();
            demonCowNextTarget();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (GaneEvent.leftHolyCattle > 0)
        {
            if (target == null)
            {
                holyCows = GameObject.FindGameObjectsWithTag("HolyCow");
                if (holyCows.Length <= 0)
                {
                    target = holyCows[0].GetComponent<Transform>();
                    demonCowNextTarget();
                }


            }
            
            switch (demonCowCurrentState)
            {
                case demonCowStates.afterAttack:
                    if (Time.time > nextAttack)
                    {

                        demonCowChangingState(demonCowStates.seeking);
                    }
                    break;

                case demonCowStates.seeking:
                    if(target == null)
                    {
                        demonCowNextTarget();
                    }                    
                    else if (target.tag != "HolyCow")
                    {
                        demonCowNextTarget();
                    }
                    if(target != null)
                        agent.SetDestination(target.position);

                    break;
                default:
                    break;
            }

            //check where to face
            if (agent.velocity.x > 0)
            {
                m_facingRight = true;
            }
            else if (agent.velocity.x < 0)
            {
                m_facingRight = false;
            }

            //flip if necesary
            if (m_facingRight)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }

    }
    public void demonCowChangingState(demonCowStates a)
    {
        demonCowCurrentState = a;
        if(demonCowCurrentState == demonCowStates.afterAttack)
        {
            nextAttack = Time.time + coolAfterAttack;
        }
    }

    private void demonCowNextTarget()
    {
        holyCows = GameObject.FindGameObjectsWithTag("HolyCow");
        target = holyCows[0].GetComponent<Transform>();
        //find the closest holycow 
        for (int i = 0; i < holyCows.Length; i++)
        {
            
                holyCows[i].GetComponent<Transform>();
                if (Vector2.Distance(holyCows[i].GetComponent<Transform>().position, transform.position) <
                    Vector2.Distance(target.position, transform.position))
                {
                    target = holyCows[i].GetComponent<Transform>();
                }
            
        }
    }
    public void killCow()
    {
        animator.SetTrigger("Death");
        --GaneEvent.amountOfDemon;        
    }

    private void Dead()
    {
        Destroy(gameObject);
    }

}
