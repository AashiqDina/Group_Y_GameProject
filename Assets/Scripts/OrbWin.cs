using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbWin : MonoBehaviour
{
    private bool collisonOccured = false;
    public int orbGained = 1;
    private GameTimer gameTimer;

    // Start is called before the first frame update
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && collisonOccured == false)
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<PlayerInteraction>().getOrb(orbGained);
            collisonOccured = true;

            //Add the code for what happens when they take the final orb
        }
    }
}
