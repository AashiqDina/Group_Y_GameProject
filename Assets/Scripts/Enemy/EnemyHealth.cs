using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public GameObject EnemyHealthBar;
    public Slider EnemyHealthSlider;

    public float MaxHealth;
    private float CurrentHealth;
    private float BulletDamage;
    public PlayerInteraction Player;
    public bool SwordCanHit = false;
    // Start is called before the first frame update
    void Awake()
    {
        CurrentHealth = MaxHealth;
        BulletDamage = GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<GunShoot>().GunDamage;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        EnemyHealthSlider.value = UpdateEnemyHealth();
        
        if(CurrentHealth <= 0){
            Destroy(gameObject);
            Player.alterEnemiesKilled(Player.getEnemiesKilled() + 1);
        }

    }

    private void OnCollisionEnter(Collision collide){
        if(collide.gameObject.tag == "Bullet" ){
            TakeDamage(BulletDamage);
        }
    }

    private float UpdateEnemyHealth(){
        return CurrentHealth/MaxHealth;
    }

    public void TakeDamage(float Damage){
        Debug.Log("Before" + CurrentHealth);
        CurrentHealth -= Damage;
        Debug.Log("After" + CurrentHealth);

    }
}
