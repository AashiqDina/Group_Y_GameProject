using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform playerLocation;
    public int EnemyDamage = 5;
    public float DamageRate;
    private float DamageLastDone;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(playerLocation.position);
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !CanDamage()){
            EnemyDamage = 0;
        }
        if (CanDamage()){
            EnemyDamage = 5;
        }
    }

    bool CanDamage(){
        if (Time.time - DamageLastDone > DamageRate){
            DamageLastDone = Time.time;
            return true;
        }
        return false;
    }
}
