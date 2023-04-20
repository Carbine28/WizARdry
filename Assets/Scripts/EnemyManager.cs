using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemyPrefab;
    public float spawnRadius = 20f;
    public int numEnemiesPerWave = 10;
    public int numWaves = 10;
    public float timeBetweenWaves = 5f;
    private float waveCount = 0;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        while (waveCount < numWaves)
        {
            yield return new WaitForSeconds(timeBetweenWaves);
            SpawnWave();
            waveCount++;
        }
    }

    private void SpawnWave()
    {
        Vector3 playerPos = player.transform.position;
        for (int i = 0; i < numEnemiesPerWave; i++)
        {
            float angle = Random.Range(0f, Mathf.PI * 2f);
            Vector3 spawnPos = playerPos + new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * spawnRadius;
            GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
            enemyMovement.player = player.transform;
        }
    }
}
