using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;


    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    /* Update()
    {

        if(Vector3.Distance(transform.position,player.transform.position) > 0.75f)
        {
            agent.SetDestination(player.transform.position);
        }
        else
        {
            agent.SetDestination(transform.position);
        }

    }*/
}
