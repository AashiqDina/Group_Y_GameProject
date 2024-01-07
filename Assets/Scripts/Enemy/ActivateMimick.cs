using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ActivateMimick : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform playerLocation;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        agent = animator.GetComponent<NavMeshAgent>();
        playerLocation = GameObject.Find("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(playerLocation.position);
    }
}
