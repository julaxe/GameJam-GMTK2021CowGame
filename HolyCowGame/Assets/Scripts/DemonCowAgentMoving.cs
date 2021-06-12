using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class DemonCowAgentMoving : MonoBehaviour
{
    private GameObject[] holyCows;
    [SerializeField] Transform target;
    private NavMeshAgent agent;
    private bool isSeeking;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = agent.updateUpAxis = false;
        isSeeking = true;
        if (target == null)
        {
            holyCows = GameObject.FindGameObjectsWithTag("HolyCow");
            target = holyCows[0].GetComponent<Transform>();
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

    // Update is called once per frame
    void Update()
    {

        if (isSeeking == true)
        {
            agent.SetDestination(target.position);
        }
    }

    public void demonCowIsSeeking(bool a)
    {
        isSeeking = a;
    }

}
