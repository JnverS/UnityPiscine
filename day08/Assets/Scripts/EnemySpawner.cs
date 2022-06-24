using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    private GameObject enemy;
    private bool flag;
    void Start()
    {
        StartCoroutine(SpawnNewEnemy());
    }

    void Update()
    {
        if (!flag) 
            StartCoroutine(SpawnNewEnemy());
    }

    private IEnumerator SpawnNewEnemy()
    {
        flag = true;
        int type = Random.Range(0, 2);
        enemy = (GameObject) Instantiate(enemies[type], transform);
        yield return new WaitForSeconds(30.0f);
        flag = false;
    }
}
