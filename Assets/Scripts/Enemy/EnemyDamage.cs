using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyDamage : MonoBehaviour
{
    public int enemydamage = 10;
    public float DamageRate;
    private float DamageLastDone;
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !CanDamage())
        {
            enemydamage = 0;
        }

    }

    bool CanDamage()
    {
        if (Time.time - DamageLastDone > DamageRate)
        {
            DamageLastDone = Time.time;
            return true;
        }
        return false;
    }
}
