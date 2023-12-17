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
    private bool NeedHealthRecovery = false;
    private bool OnGround = false;
    
    [SerializeField] private Transform CheckGround;
    [SerializeField] private float GroundRadius;
    [SerializeField] private LayerMask PlatformLM;

    // Start is called before the first frame update
    void Awake()
    {
        transform.position = spawnPoint.position;
        health.setMaxHealth(maxHealth);
        currentHealth = maxHealth;
        numberOfOrbs = 0;
    }

    // Update is called once per frame
    void Update(){
        RespawnHeal();
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            currentHealth -= collision.gameObject.GetComponent<EnemyMovement>().EnemyDamage;
        }
        health.ChangeHealth(currentHealth);
        if (currentHealth == 0)
        {
            Respawn();
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

    void Respawn(){
        Debug.Log("Gameover");
        transform.position = spawnPoint.position;
        NeedHealthRecovery = true;
    }

    void RespawnHeal(){
        OnGround = Physics.CheckSphere(CheckGround.position, GroundRadius, (int)PlatformLM);
        if(OnGround && NeedHealthRecovery){
            currentHealth = maxHealth;
            NeedHealthRecovery = false;
        }
    }

}
