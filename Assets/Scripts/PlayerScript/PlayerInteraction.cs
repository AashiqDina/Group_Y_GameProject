using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public int maxHealth;
    public int maxOrbs;
    private int currentHealth;
    private int numberOfOrbs = 0;
    private int EnemiesKilled = 0;
    private int PlayerScore = 0;
    private string HealthStat;
    private float LastCollected;
    public Heath health;
    public NumberOrbs numberOrbs;
    public Stats score;
    public Stats enemiesKilled;
    public Stats CurrentHealthStat;
    public List<Transform> spawnPoint;
    private bool NeedHealthRecovery = false;
    private bool OnGround = false;
    
    [SerializeField] private Transform CheckGround;
    [SerializeField] private float GroundRadius;
    [SerializeField] private LayerMask PlatformLM;

    // Start is called before the first frame update
    void Awake()
    {
        transform.position = spawnPoint[0].position;
        health.setMaxHealth(maxHealth);
        currentHealth = maxHealth;
        numberOfOrbs = 0;
        HealthStat = currentHealth.ToString() + "/" + maxHealth.ToString();
        CurrentHealthStat.updateHealthStat(HealthStat);
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
            HealthStat = currentHealth.ToString() + "/" + maxHealth.ToString();
            CurrentHealthStat.updateHealthStat(HealthStat);
        }
        health.ChangeHealth(currentHealth);
        if (currentHealth == 0)
        {
            Respawn();
        }
        if (collision.gameObject.tag == "Orb" && CanCollect())
        {
            Destroy(collision.gameObject);
            numberOfOrbs += 1;
            numberOrbs.changeText(numberOfOrbs);
            PlayerScore += 500;
            score.changeScore(PlayerScore);
            transform.position = spawnPoint[numberOfOrbs].position;


        }
        if (numberOfOrbs == maxOrbs)
        {
            Debug.Log("Win");
        }
    }

    void Respawn(){
        Debug.Log("Gameover");
        transform.position = spawnPoint[numberOfOrbs].position;
        NeedHealthRecovery = true;
    }

    void RespawnHeal(){
        OnGround = Physics.CheckSphere(CheckGround.position, GroundRadius, (int)PlatformLM);
        if(OnGround && NeedHealthRecovery){
            currentHealth = maxHealth;
            NeedHealthRecovery = false;
            HealthStat = currentHealth.ToString() + "/" + maxHealth.ToString();
            CurrentHealthStat.updateHealthStat(HealthStat);
        }
    }

    bool CanCollect(){
        if (Time.time - LastCollected > 0.1){
            LastCollected = Time.time;
            return true;
        }
        return false;
    }

    public int getEnemiesKilled(){
        return EnemiesKilled;
    }

    public void alterEnemiesKilled(int newValue){
        Debug.Log("Here");
        EnemiesKilled = newValue;
        enemiesKilled.changeEnemiesKilledText(EnemiesKilled);
        PlayerScore += 100;
        score.changeScore(PlayerScore);
    }
}
