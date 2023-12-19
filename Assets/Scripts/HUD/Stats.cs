using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public Text Score;
    public Text EnemiesKilled;
    public Text CurrentHealth;
    // Start is called before the first frame update
    void Awake()
    {
        if (Score != null){
            Score.text = "Current Score: 0";
        }
        if (EnemiesKilled != null){
            EnemiesKilled.text = "Enemies Killed: 0";
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeScore(int score){
        Score.text = "Current Score: " + score.ToString();
    }

    public void changeEnemiesKilledText(int eKilled){
        EnemiesKilled.text = "Enemies Killed: " + eKilled.ToString();
    }

    public void updateHealthStat(string Health){
        CurrentHealth.text = "Current Health: " + Health;
    }
}
