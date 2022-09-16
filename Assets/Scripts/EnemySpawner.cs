using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float startDelay = 2.0f;
    public float repeatDelay = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, repeatDelay);
    }
     void SpawnEnemy()
    {
        Vector3 spawnLocation1 = new Vector2(8.5f,4.5f);
        Vector3 spawnLocation2 = new Vector2(8.5f,-4.5f);
        Vector3 spawnLocation3 = new Vector2(-8.5f,-4.5f);
        Vector3 spawnLocation4 = new Vector2(-8.5f,4.5f);
        Instantiate(enemyPrefab, spawnLocation1, enemyPrefab.transform.rotation);
        Instantiate(enemyPrefab, spawnLocation2, enemyPrefab.transform.rotation);
        Instantiate(enemyPrefab, spawnLocation3, enemyPrefab.transform.rotation);
        Instantiate(enemyPrefab, spawnLocation4, enemyPrefab.transform.rotation);
    }
}
