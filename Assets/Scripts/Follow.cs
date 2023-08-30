using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public Transform tank;

    private Movement moves;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        moves = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moves.Tank == false)
        {
            agent.SetDestination(player.position);
        }
        else if(moves.Tank == true) 
        {
            agent.SetDestination(tank.position);
        }
        
    }
}
