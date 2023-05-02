using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

[System.Serializable]
public class GameObjectEvent : UnityEvent< List<GameObject> > {};


public class EnemyManager : MonoBehaviour
{
    [SerializeField] private AudioClip wave_cleared;
    public GameObject player;
    public GameObject enemyPrefab;
    public float spawnRadius = 20f;
    
    // How many waves
    [SerializeField] private int maxWaves = 5;
    // How many enemies per wave?
    [SerializeField] private int maxEnemies = 3;
    [SerializeField] private int additionalEnemies = 2; // Add 2 more enemies per wave
    private int enemiesSpawned = 0; // Count for enemies in a wave spawned.
    private int enemiesDefeated = 0; // Count if a wave is complete
    // During a wave whats the spawn frequency?
    [SerializeField] private float spawnFrequency = 6.0f;
    [SerializeField] private float frequencyReduction = 0.8f; // Lower means enemies spawn faster
    // How long in between waves as rest
    [SerializeField] private float waveRestTime = 8.0f;
    [SerializeField] private float RestTimeReduction = 0.6f; // Lower means less time in-between waves

    private int currentWaveCount = 0;

    public IntEvent on_enemy_death;
    public UnityEvent on_wave_cleared;

    public GameObjectEvent on_enemy_added;

    public List<GameObject> enemyGameObjects = new List<GameObject>();

    
    private void Start()
    {
        currentWaveCount = 0; // Reset wave count
        currentWaveCount++; // Increment 1 for first wave
        StartCoroutine(SpawnWave()); // Start spawning enemies in waves
    }

    private IEnumerator SpawnWave(){
        while(enemiesSpawned < maxEnemies){
            yield return new WaitForSeconds(spawnFrequency);
            SpawnEnemy();
        }
        while (enemiesSpawned >= maxEnemies){
            // All enemies have been spawned but still need to wait for player to kill them first.
            yield return new WaitForSeconds(1f);
            if (enemiesDefeated == maxEnemies){
                print("End of Wave: " + currentWaveCount);
                currentWaveCount  += 1; // Update wave count
                checkWave();  // Check if final wave is over

                yield return new WaitForSeconds(waveRestTime); // Apply rest time
                setupNextWave(); // Then setup next wave if not over
            }            
        }
    }

    private void SpawnEnemy(){
        // Calculate spawn position
        Vector3 playerPos = player.transform.position; // Get Position of player
        float angle = Random.Range(0f, Mathf.PI * 2f); 
        Vector3 spawnPos = playerPos + new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * spawnRadius; // Spawn enemy around player 
        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

        // Set enemy movement variables
        EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
        enemyMovement.player = player.transform;
        enemy.transform.SetParent(this.transform);
        // Add Event listener
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        enemyScript.enemyDefeated.AddListener(on_Enemy_Death);
        // Invoke indicator event
        enemyGameObjects.Add(enemy);
        on_enemy_added.Invoke(enemyGameObjects);

        enemiesSpawned += 1; // Add one to enemies spawned
    }

    // Update spawning parameters of next wave
    private void setupNextWave(){
        spawnFrequency = spawnFrequency * frequencyReduction; // Make enemy spawn faster
        waveRestTime = waveRestTime * RestTimeReduction; // Shorten rest time in between waves

        // Reset enemy killed and spawned
        enemiesDefeated = 0;
        enemiesSpawned = 0;
        
        maxEnemies += additionalEnemies; // Add more enemies in the next wave
        print("Next Wave Start");
        on_wave_cleared.Invoke();
        StopAllCoroutines();
        StartCoroutine(SpawnWave()); // Start next wave
    }

    // Check if wave has reached final wave
    private void checkWave(){
        if (currentWaveCount > maxWaves){
            // Stop spawning waves
            StopAllCoroutines();
            // Switch to next scene: i.e win scene
            print("You win!");
            SceneManager.LoadScene(sceneName:"WinScreen"); // Open the main menu
        }
        else{
            
            SoundManager.Instance.PlaySound(wave_cleared);
            
        }
    }

    private void on_Enemy_Death(int score, GameObject enemyObject){
        enemiesDefeated += 1;
        print("enemy dead");
        // 
        enemyGameObjects.Remove(enemyObject);
        on_enemy_added.Invoke(enemyGameObjects);
        // Update score here
        on_enemy_death.Invoke(score, null); // Event passed to UI to update score
    }
}
