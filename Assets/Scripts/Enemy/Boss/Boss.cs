using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public Transform bossSpawnPoint;
    public GameObject BossHealthBar;
    public GameObject Orb;
    public int Damage;
    public int maxhealth = 300;
    // Start is called before the first frame update

    public void restart()
    {
        Debug.Log("restart");
        GetComponent<Animator>().SetTrigger("death");
        BossHealthBar.GetComponent<Slider>().value = maxhealth;
        BossHealthBar.SetActive(false);
        GetComponent<EnemyHealth>().enabled = false;
        transform.position = bossSpawnPoint.position;
        GetComponent<Animator>().SetTrigger("enterIdle");
    }
    public void activatecombat()
    {
        BossHealthBar.SetActive(true);
        GetComponent<EnemyHealth>().enabled = true;
        BossHealthBar.GetComponent<Slider>().maxValue = maxhealth;
    }

    private void Update()
    {
        if(BossHealthBar.GetComponent<Slider>().value <= 0)
        {
            BossHealthBar.SetActive(false);
            Orb.SetActive(true);
        }
    }

}
