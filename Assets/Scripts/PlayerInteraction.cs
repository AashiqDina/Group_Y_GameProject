using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;
    public Heath health;
    // Start is called before the first frame update
    void Start()
    {
        health.setMaxHealth(maxHealth);
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth == 0)
        {
            Debug.Log("Gameover");
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            currentHealth -= 1;
        }
        health.ChangeHealth(currentHealth);
    }

}
