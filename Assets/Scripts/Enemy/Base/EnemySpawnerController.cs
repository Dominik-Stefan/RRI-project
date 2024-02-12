using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Waves;

public class EnemySpawnerController : MonoBehaviour
{
    public GameObject bombPrefab;
    public GameObject treasurePrefab;
    public GameObject boss1;
    public GameObject boss2;
    public float interval = 100;
    public float spawnRadius = 20;
    private float counter = 0;
    private List<Wave> allWaves = new List<Wave> { new Wave1(), new Wave2(), new Wave3(), new Wave4(), new Wave5() };
    private int chosenWave = 0;

    void Start()
    {
        StartCoroutine(ManageWaves());
        StartCoroutine(SpawnBosses());
    }

    IEnumerator ManageWaves()
    {
        for (int i = 0; i < allWaves.Count - 1; i++)
        {
            yield return new WaitForSeconds(180f);
            interval -= 4;
            chosenWave += 1;
        }
        chosenWave -= 1;
    }

    IEnumerator SpawnBosses()
    {
        yield return new WaitForSeconds(300f);
        Vector2 spawnPosition = (Vector2)transform.position - Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(boss1, spawnPosition, transform.rotation);

        yield return new WaitForSeconds(300f);
        spawnPosition = (Vector2)transform.position - Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(boss1, spawnPosition, transform.rotation);
        spawnPosition = (Vector2)transform.position - Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(boss1, spawnPosition, transform.rotation);

        yield return new WaitForSeconds(180f);
        spawnPosition = (Vector2)transform.position - Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(boss2, spawnPosition, transform.rotation);

        yield return new WaitForSeconds(120f);
        GameObject.Find("GameController").GetComponent<GameController>().GameDone();
    }

    void FixedUpdate()
    {
        counter += 1;

        if (counter >= interval)
        {
            counter = 0;

            Vector2 spawnPosition = (Vector2)transform.position - Random.insideUnitCircle.normalized * spawnRadius;
            string nameOfObject = null;
            int rand = Random.Range(1, 100);
            bool found = false;
            int sum = 0;

            if (rand <= allWaves[chosenWave].bombChance && !found)
            {
                Instantiate(bombPrefab, spawnPosition, transform.rotation);
                found = true;
            }
            sum += allWaves[chosenWave].bombChance;

            if (rand <= sum + allWaves[chosenWave].treasureChance && !found)
            {
                Instantiate(treasurePrefab, spawnPosition, transform.rotation);
                found = true;
            }
            sum += allWaves[chosenWave].treasureChance;

            if (rand <= sum + allWaves[chosenWave].gunslinger1Chance && !found)
            {
                nameOfObject = "Enemy_Gunman1(Clone)";
                found = true;
            }
            sum += allWaves[chosenWave].gunslinger1Chance;

            if (rand <= sum + allWaves[chosenWave].gunslinger2Chance && !found)
            {
                nameOfObject = "Enemy_Gunman2(Clone)";
                found = true;
            }
            sum += allWaves[chosenWave].gunslinger2Chance;

            if (rand <= sum + allWaves[chosenWave].gunslinger3Chance && !found)
            {
                nameOfObject = "Enemy_Gunman3(Clone)";
                found = true;
            }
            sum += allWaves[chosenWave].gunslinger3Chance;

            if (rand <= sum + allWaves[chosenWave].slime1Chance && !found)
            {
                nameOfObject = "Enemy_Slime1(Clone)";
                found = true;
            }
            sum += allWaves[chosenWave].slime1Chance;

            if (rand <= sum + allWaves[chosenWave].slime2Chance && !found)
            {
                nameOfObject = "Enemy_Slime2(Clone)";
                found = true;
            }
            sum += allWaves[chosenWave].slime2Chance;

            if (rand <= sum + allWaves[chosenWave].slime3Chance && !found)
            {
                nameOfObject = "Enemy_Slime3(Clone)";
                found = true;
            }

            if (nameOfObject != null)
            {
                GameObject enemy = EnemyObjectPool.SharedInstance.getPooledEnemyObject(nameOfObject);
                if (enemy != null)
                {
                    enemy.transform.position = spawnPosition;
                    enemy.transform.rotation = transform.rotation;
                    enemy.SetActive(true);
                }
            }
        }
    }
}
