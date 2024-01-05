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
    public Heath health;
    public NumberOrbs numberOrbs;
    public Stats score;
    public Stats enemiesKilled;
    public Stats CurrentHealthStat;
    public Transform CurrentSpawnPoint;

    private bool NeedHealthRecovery = false;
    private bool OnGround = false;

    public CreateEnemies createEnemies;
    
    [SerializeField] private GameObject Boss;
    [SerializeField] private Transform CheckGround;
    [SerializeField] private float GroundRadius;
    [SerializeField] private LayerMask PlatformLM;

    // Start is called before the first frame update
    void Awake()
    {
        transform.position = CurrentSpawnPoint.position;
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
            currentHealth -= collision.gameObject.GetComponent<EnemyDamage>().enemydamage;
            HealthStat = currentHealth.ToString() + "/" + maxHealth.ToString();
            CurrentHealthStat.updateHealthStat(HealthStat);
        }
        
        health.ChangeHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Respawn();
        }
    }

    void Respawn(){
        Debug.Log("Gameover");
        transform.position = CurrentSpawnPoint.position;
        NeedHealthRecovery = true;
        Boss.GetComponent<Boss>().restart();
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
    public void getOrb(int orbGained)
    {
        numberOfOrbs += orbGained;
        numberOrbs.changeText(numberOfOrbs);
        PlayerScore += 500;
        score.changeScore(PlayerScore);
        if (numberOfOrbs == 1)
        {
            createEnemies.StartSpawn();
        }
        else
        {
            createEnemies.SelfDestruct();
        }
        if (numberOfOrbs == 4)
        {
            Boss.GetComponent<Animator>().SetTrigger("enterIdle");
        }
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
