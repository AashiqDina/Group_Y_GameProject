using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float BulletDamage;
    public GameObject Gun;
    // Start is called before the first frame update
    void Awake()
    {
        BulletDamage = GameObject.Find("Player").transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<GunShoot>().GunDamage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collide){

        Destroy(gameObject);
    }
}
