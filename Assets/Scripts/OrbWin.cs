using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class OrbWin : MonoBehaviour
{
    private bool collisonOccured = false;
    public int orbGained = 1;
    public GameObject gameTimer;

    // Start is called before the first frame update
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && collisonOccured == false)
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<PlayerInteraction>().getOrb(orbGained);
            collisonOccured = true;
            gameTimer.GetComponent<GameTimer>().StopTimer();
        }
    }
}*/


public class OrbWin : MonoBehaviour
{
    private bool collisionOccurred = false;
    public int orbGained = 1;
    public GameObject gameTimer;
    public GameObject endScreenManager; // Add this reference

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

