using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemy;
    public CreateEnemies createEnemies;
    private void OnTriggerEnter(Collider player)
    {
        if(player.tag == "Player")
        {
            createEnemies.StartSpawn();
        }

    }

    private void OnTriggerExit(Collider player)
    {
        if (player.tag == "Player")
        {
            createEnemies.SelfDestruct();
        }
            
    }
}
