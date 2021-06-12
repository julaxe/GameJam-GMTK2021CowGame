using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject demonCattle;

    private float time;
    [SerializeField]
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(GaneEvent.amountOfDemon < GaneEvent.totalAmountOfDemon)
        {
            
            if(time >= timer)
            {
                //Respawn 
                //Instantiate(demonCattle, transform.position, Quaternion.identity);
                time = 0f;
            }
            time += Time.deltaTime;
            
        }
    }
}
