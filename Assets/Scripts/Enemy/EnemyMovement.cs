using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform playerLocation;


    // Start is called before the first frame update


    // Update is called once per frame
    void FixedUpdate()
    {
        agent.SetDestination(playerLocation.position);
    }


}
