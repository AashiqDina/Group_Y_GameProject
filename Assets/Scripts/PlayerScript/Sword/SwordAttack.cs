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
    private bool CanAttack = false;

    // Start is called before the first frame update
    void Awake()
    {
        input = new Input();
        swordAction = input.SwordSwingAttack;
        attack = swordAction.ToAttack;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PermitAttack();
    }

    private void OnEnable()
    {
        swordAction.Enable();
    }

     void OnTriggerStay(Collider collision){
        if(collision.gameObject.tag == "Enemy" && CanAttack){
            Debug.Log("Before: " + CanAttack);
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(SwordDamage);
            CanAttack = false;
            Debug.Log("After: " + CanAttack);
        }
     }

     void PermitAttack(){
        if(attack.triggered && attack.ReadValue<float>() > 0){
            CanAttack = true;
        }
        else{ 
            CanAttack = false;
        };
     }
}
