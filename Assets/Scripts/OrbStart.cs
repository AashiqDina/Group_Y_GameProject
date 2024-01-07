using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbStart : MonoBehaviour
{
    private bool collisonOccured = false;
    public Transform teleportTo;
    public GameObject gameTimer;

    // Start is called before the first frame update
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && collisonOccured == false)
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<PlayerInteraction>().CurrentSpawnPoint = teleportTo;
            collision.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            collision.gameObject.transform.position = teleportTo.position;
            collisonOccured = true;
            gameTimer.GetComponent<GameTimer>().StartTimer();
        }
    }
}