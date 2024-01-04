using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public Slider EnemyHealthSlider;


    private float BulletDamage;
    private float LaserDamage;
    private float MagicDamage;

    public PlayerInteraction Player;
    public bool SwordCanHit = false;
    // Start is called before the first frame update
    void Awake()
    {

        BulletDamage = GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<GunShoot>().GunDamage;
        LaserDamage = GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<GunShoot>().GunDamage;
        MagicDamage = GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.GetComponent<GunShoot>().GunDamage;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(EnemyHealthSlider.value <= 0){
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

    public void TakeDamage(float Damage){
        EnemyHealthSlider.value -= Damage;

    }
}
