using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbWin : MonoBehaviour
{
    private bool collisionOccurred = false;
    public int orbGained = 1;
    public GameObject gameTimer;
    public GameObject endScreenManager;

    // Start is called before the first frame update
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !collisionOccurred)
        {
            Destroy(gameObject);
            PlayerInteraction playerInteraction = collision.gameObject.GetComponent<PlayerInteraction>();
            playerInteraction.getOrb(orbGained);
            collisionOccurred = true;

            gameTimer.GetComponent<GameTimer>().StopTimer();

            // Check if all orbs are collected

            endScreenManager.GetComponent<EndScreenManager>().ShowEndScreen(); // Show the end screen
        }
    }
}

