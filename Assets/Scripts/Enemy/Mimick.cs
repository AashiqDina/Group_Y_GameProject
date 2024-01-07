using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mimick : MonoBehaviour
{
    // Start is called before the first frame update
    public int damageAmount = 10;
    void Awake()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        GetComponent<EnemyDamage>().enemydamage = 0;
        GetComponent<EnemyHealth>().enabled = false;
    }

    // Update is called once per frame
    public void Activate()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        GetComponent<EnemyDamage>().enemydamage = damageAmount;
        GetComponent<EnemyHealth>().enabled = true;
        GetComponent<Animator>().SetTrigger("Awaken");
    }
}
