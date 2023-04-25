using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{

    [SerializeField] private GameObject player_camera;

    // I would generally create a player health script
    [SerializeField] private int player_health = 3;

    public UnityEvent player_DeathEvent;
    
    void Update()
    {
        transform.position = player_camera.transform.position;
    }

    public void player_hit(){
        player_health -= 1;
        check_player_health();
    }

    private void check_player_health(){
        if (player_health <= 0){
            player_DeathEvent.Invoke();
        }
    }
}
