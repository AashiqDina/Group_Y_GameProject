using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
public class GunShoot : MonoBehaviour
{

    private Input input;
    private Input.GunShootActions gunShoot;
    private InputAction shoot;
    public Transform BulletSpawn;
    public GameObject Bullet;
    public float BulletSpeed;
    private float LastShotTime;
    public float FireRate;
    private float DistanceAway;
    public float GunRange;
    public int Ammo;
    private bool NeedToReload;
    private Rigidbody PlayerRB;
    public float GunDamage;
    private GameObject Camera;


    // Start is called before the first frame update
    void Awake()
    {       
        input = new Input();
        gunShoot = input.GunShoot;
        shoot = gunShoot.Shoot;
        

        PlayerRB = GameObject.Find("Player").GetComponent<Rigidbody>();
        Camera = GameObject.Find("Player").transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerShoot();
    }

    private void OnEnable()
    {
        gunShoot.Enable();
    }

    void PlayerShoot(){
        if(shoot.ReadValue<float>() > 0 && CanShoot()){
            Debug.Log("shoot");
            var bullet = Instantiate(Bullet, BulletSpawn.position, BulletSpawn.rotation);
            if(PlayerRB.velocity.magnitude > 1 && PlayerRB.velocity.magnitude < 1000){
                DistanceAway = Camera.GetComponent<CameraRaycast>().CheckDistance(GunRange);
                bullet.transform.Rotate(0,(float)(360.0 -(Math.Atan(DistanceAway/1)*180/Math.PI)),0, Space.Self);
                Debug.Log((float)(360.0 -(Math.Atan(DistanceAway/1)*180/Math.PI)));
                bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * BulletSpeed + (PlayerRB.velocity.magnitude * PlayerRB.velocity.normalized);
            }
            else{
                bullet.transform.Rotate(0,(float)(360.0 -(Math.Atan(DistanceAway/1)*180/Math.PI)),0, Space.Self);
                bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * BulletSpeed;
            }
        }
    }

    bool CanShoot(){
        if (Time.time - LastShotTime > FireRate){
            LastShotTime = Time.time;
            return true;
        }
        return false;
    }
}
