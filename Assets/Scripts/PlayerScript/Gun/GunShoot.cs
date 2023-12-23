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
    private float LastUsed;
    public float FireRate;
    private float DistanceAway;
    public float GunRange;
    public int Ammo;
    private bool NeedToReload;
    private Rigidbody PlayerRB;
    public float GunDamage;
    private GameObject Camera;
    public bool hasEffects;


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
        EnableEffect();
        if(shoot.ReadValue<float>() > 0 && CanShoot()){
            Debug.Log("shoot");
            LastUsed = Time.time;
            EnableEffect();
            var bullet = Instantiate(Bullet, BulletSpawn.position, BulletSpawn.rotation);
            if(PlayerRB.velocity.magnitude > 1 && PlayerRB.velocity.magnitude < 1000){
                Debug.Log("Can Shoot");
                DistanceAway = Camera.GetComponent<CameraRaycast>().CheckDistance(GunRange);
                if(DistanceAway != 0){
                    bullet.transform.Rotate(0,(float)(360.0 - (90 - (Math.Atan(DistanceAway/1)*180/Math.PI))),0, Space.Self);
                }
                Debug.Log("angle: " + (float)(360.0 -(Math.Atan(DistanceAway/1)*180/Math.PI)) + ", DistanceAway: " + DistanceAway);
                bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * BulletSpeed + (PlayerRB.velocity.magnitude * PlayerRB.velocity.normalized);
            }
            else{
                if(DistanceAway != 0){
                    bullet.transform.Rotate(0,(float)(360.0 - (90 - (Math.Atan(DistanceAway/1)*180/Math.PI))),0, Space.Self);
                }
                Debug.Log("angle: " + (float)(360.0 -(Math.Atan(DistanceAway/1)*180/Math.PI)) + ", DistanceAway: " + DistanceAway);
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

    void EnableEffect(){
        if(Time.time - LastUsed < 0.05){
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
        else{
            if(hasEffects){
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.Rotate(0,0,UnityEngine.Random.Range(0,45));
            }

        }
    }
}
