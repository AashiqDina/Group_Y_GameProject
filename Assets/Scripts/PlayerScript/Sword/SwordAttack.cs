using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwordAttack : MonoBehaviour
{
    private Input input;
    private Input.SwordSwingAttackActions swordAction;
    private InputAction attack;
    public float SwordDamage;
    public float AttackRate;
    private float LastHitTime;
    private bool CanAttack = false;
    [SerializeField] private GameObject Weapon;


    // Start is called before the first frame update
    void Awake()
    {
        input = new Input();
        swordAction = input.SwordSwingAttack;
        attack = swordAction.ToAttack;
    }

    // Update is called once per frame

    private void OnEnable()
    {
        attack.Enable();
        attack.performed += Attack;
    }

    private void OnDisable()
    {
        attack.Disable();
    }

    void OnTriggerStay(Collider collision){
        if(collision.gameObject.tag == "Enemy" && CanAttack){
            Debug.Log("Before: " + CanAttack);
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(SwordDamage);
            CanAttack = false;
            Debug.Log("After: " + CanAttack);
        }
     }

     void Attack(InputAction.CallbackContext context){
        Debug.Log("Attack");
        
        if ((attack.ReadValue<float>() > 0) && (Time.time - LastHitTime > AttackRate)){
            CanAttack = true;
            Weapon.GetComponent<Animator>().SetTrigger("Swing");
            LastHitTime = Time.time;
        }
        else{ 
            CanAttack = false;
        };
     }
}
