using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public int maxHealth;
    public int maxOrbs;
    private int currentHealth;
    private int numberOfOrbs = 0;
    public Heath health;
    public NumberOrbs numberOrbs;

    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        health.setMaxHealth(maxHealth);
        currentHealth = maxHealth;
        transform.position = spawnPoint.position;
    }

    // Update is called once per frame


    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            currentHealth -= 1;
        }
        health.ChangeHealth(currentHealth);
        if (currentHealth == 0)
        {
            Debug.Log("Gameover");
            transform.position = spawnPoint.position;
            currentHealth = maxHealth;
        }
        if (collision.gameObject.tag == "Orb")
        {
            Destroy(collision.gameObject);
            numberOfOrbs += 1;
            numberOrbs.changeText(numberOfOrbs);
        }
        if (numberOfOrbs == maxOrbs)
        {
            Debug.Log("Win");
        }
    }

}
