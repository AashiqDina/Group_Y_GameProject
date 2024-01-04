using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CreateEnemies : MonoBehaviour
{
    public GameObject enemy;
    private List<GameObject> clone = new List<GameObject>();
    public List<Transform> spawnPoints;

    void Start()
    {
        enemy.SetActive(false);
    }
    // Start is called before the first frame update
    public void StartSpawn()
    {

        enemy.SetActive(true);
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            clone.Add(Instantiate(enemy, spawnPoints[i].position, Quaternion.identity));
        }
        enemy.SetActive(false);

    }

    public void SelfDestruct()
    {
        foreach(GameObject i in clone)
        {
            Destroy(i);
        }
        
    }
}
