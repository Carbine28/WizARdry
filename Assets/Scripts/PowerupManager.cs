using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PowerupManager : MonoBehaviour
{

    [SerializeField] private GameObject _EnemyManager;
    [SerializeField] private GameObject playerObjet;
    public GameObject heartPrefab;
    public GameObject player;
    public float spawnRadius = 5f;

    public UnityEvent powerup_obtained;

    // Start is called before the first frame update
    void Start()
    {
        // Add event listener for next wave
        EnemyManager enemyManager_script = _EnemyManager.GetComponent<EnemyManager>();
        enemyManager_script.on_wave_cleared.AddListener(SpawnPowerup);

    }

    private void SpawnPowerup(){
        // Calculate spawn position
        Vector3 playerPos = player.transform.position; // Get Position of player
        float angle = Random.Range(0f, Mathf.PI * 2f); 
        Vector3 spawnPos = playerPos + new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * spawnRadius; // Spawn enemy around player 
        GameObject powerup = Instantiate(heartPrefab, spawnPos, Quaternion.identity);

        // Add Event listener
        HeartPowerup powerupScript = powerup.GetComponent<HeartPowerup>();
        powerupScript.heartHit.AddListener(on_Heart_Hit);
    }

    private void on_Heart_Hit() {
        powerup_obtained.Invoke();
    }

}
