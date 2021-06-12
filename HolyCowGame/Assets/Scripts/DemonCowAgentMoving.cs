using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class DemonCowAgentMoving : MonoBehaviour
{
    private GameObject[] holyCows;
    [SerializeField] Transform target;
    private NavMeshAgent agent;
    [SerializeField] private float coolAfterAttack = 2.0f;
    private float nextAttack = 0.0f;
    public enum demonCowStates { afterAttack, seeking};
    private demonCowStates demonCowCurrentState;

    // Start is called before the first frame update
    void Start()
    {
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
        Debug.Log(demonCowCurrentState);
        switch(demonCowCurrentState)
        {
            case demonCowStates.afterAttack:
                if(Time.time > nextAttack)
                {
                    demonCowChangingState(demonCowStates.seeking);
                }
                break;
            
            case demonCowStates.seeking:
                if(target.tag != "HolyCow")
                {
                    demonCowNextTarget();
                }
                agent.SetDestination(target.position);
                break;
            default:
            break;
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
        //find the closest holycow 
        for (int i = 0; i < holyCows.Length; i++)
        {
            holyCows[i].GetComponent<Transform>();
            if(Vector2.Distance(holyCows[i].GetComponent<Transform>().position, transform.position) < 
                Vector2.Distance(target.position, transform.position))
            {
                target = holyCows[i].GetComponent<Transform>();
            }
        }
    }

}
