using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float interval = 100;
    public float spawnRadius = 20;
    private float counter = 0;

    void FixedUpdate()
    {
        counter += 1;

        if (counter >= interval)
        {
            counter = 0;
            Vector2 spawnPosition = (Vector2)transform.position - Random.insideUnitCircle.normalized * spawnRadius;
            Instantiate(enemyPrefab, spawnPosition, transform.rotation);
        }
    }
}
