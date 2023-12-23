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
    private float LaserDamage;
    private float MagicDamage;

    public PlayerInteraction Player;
    public bool SwordCanHit = false;
    // Start is called before the first frame update
    void Awake()
    {
        CurrentHealth = MaxHealth;
        BulletDamage = GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<GunShoot>().GunDamage;
        LaserDamage = GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<GunShoot>().GunDamage;
        MagicDamage = GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.GetComponent<GunShoot>().GunDamage;
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
        else if(collide.gameObject.tag == "BulletLaser"){
            TakeDamage(LaserDamage);
        }
        else if(collide.gameObject.tag == "BulletMagic"){
            TakeDamage(MagicDamage);
        }
    }

    private float UpdateEnemyHealth(){
        return CurrentHealth/MaxHealth;
    }

    public void TakeDamage(float Damage){
        CurrentHealth -= Damage;

    }
}
