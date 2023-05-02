using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject heartContainer;
    [SerializeField] private GameObject heartPrefab;
    [SerializeField] private TextMeshProUGUI WaveCounter;
    [SerializeField] private TextMeshProUGUI ScoreCounter;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _EnemyManager;

    private int current_score;
    private int current_wave;
    private int current_player_health = 0;


    void Start() {
        // Update player UI 
        Player player_script = _player.GetComponent<Player>();
        player_script.on_player_hit.AddListener(removeHeart);
        int player_hp = player_script.player_health;
        addHearts(player_hp); // Update Hearts to match player health
        // Add event listener Score UI
        EnemyManager enemyManager_script = _EnemyManager.GetComponent<EnemyManager>();
        enemyManager_script.on_enemy_death.AddListener(addScore);
        // Add event listener Wave UI
        enemyManager_script.on_wave_cleared.AddListener(updateWave);
        
        // Initialise Score and Wave UI
        addScore(0);
        updateWave();
        
    }


    private void addScore(int score){
        current_score += score;
        ScoreCounter.text = "SCORE: " + current_score.ToString();
    }

    // Add Hearts based on player Health;
    private void addHearts(int numHearts){
        for (int i = 0; i < numHearts; i++){
            current_player_health += 1;
            GameObject heart = Instantiate(heartPrefab);
            heart.transform.SetParent(heartContainer.transform, false);
        }
    }

    // Removes the last heart in heart container
    private void removeHeart(){
        current_player_health -= 1;
        if (current_player_health > 0){
            Transform last_heart = heartContainer.transform.GetChild(heartContainer.transform.childCount - 1);
            Destroy(last_heart.gameObject);
        }
    }

    private void updateWave(){
        current_wave += 1;
        WaveCounter.text = "WAVE: " + current_wave.ToString();
    }

}
