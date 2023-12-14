using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
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
    public int Ammo;
    private bool NeedToReload;
    private Rigidbody PlayerRB;


    // Start is called before the first frame update
    void Awake()
    {       
        input = new Input();
        gunShoot = input.GunShoot;
        shoot = gunShoot.Shoot;

        PlayerRB = GameObject.Find("Player").GetComponent<Rigidbody>();
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
                bullet.GetComponent<Rigidbody>().velocity = BulletSpawn.forward * BulletSpeed + (PlayerRB.velocity.magnitude * PlayerRB.velocity.normalized);
            }
            else{
                bullet.GetComponent<Rigidbody>().velocity = BulletSpawn.forward * BulletSpeed;
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
