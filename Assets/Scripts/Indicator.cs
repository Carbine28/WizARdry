using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    [SerializeField] private GameObject _enemyManager;

    private GameObject closest_enemy;
    private GameObject chosen_enemy;
    [SerializeField] private GameObject player;
    private float shortest_distance = 999.0f;
    public List<GameObject> enemyList = new List<GameObject>();

    private void Start(){
        EnemyManager _enemyManagerScript = _enemyManager.GetComponent<EnemyManager>();
        _enemyManagerScript.on_enemy_added.AddListener(copyEnemyToList);
        _enemyManagerScript.on_wave_cleared.AddListener(clearEnemyList);
    }

    private void LateUpdate(){
        track_enemy();
    }

    private void find_closest_enemy(){
        shortest_distance = 999.0f;
        foreach(GameObject enemy in enemyList){
            float enemy_distance = Vector3.Distance(enemy.transform.position, player.transform.position);
            if(enemy_distance < shortest_distance){
                shortest_distance = enemy_distance;
                chosen_enemy = enemy;
            }
        }
    }


    private void track_enemy(){
        if(chosen_enemy != null){
            // Track enemy
            transform.LookAt(chosen_enemy.transform);
        }
    }

    private void copyEnemyToList(List<GameObject> enemy_objects){
        print("Copied List");
        enemyList = enemy_objects;
        find_closest_enemy();
        // _instantiatedEnemies[enemy_object.name] = enemy_object;
    }

    private void clearEnemyList(){
        chosen_enemy = null;
        enemyList.Clear();
    }
    

     
}
