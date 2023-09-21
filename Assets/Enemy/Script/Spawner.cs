using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    float timer;
    int count;
    PoolManager enemyPoolManager;
    public int EnemyCount;
    private void Awake()
    {
        enemyPoolManager = GameObject.Find("EnemyPoolManager").GetComponent<PoolManager>();
        spawnPoint = GetComponentsInChildren<Transform>();
    }    
    private void Update()
    {               
        Spawn();               
    }

    void Spawn()
    {
        GameObject enemy = enemyPoolManager.Get(0);
        enemy.transform.position = spawnPoint[Random.Range(1,spawnPoint.Length)].position;        
    }
}
