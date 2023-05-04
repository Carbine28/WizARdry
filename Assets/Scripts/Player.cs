using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{

    [SerializeField] private GameObject player_camera;
    [SerializeField] private GameObject _PowerupManager;

    // I would generally create a player health script
    public int player_health = 5;
    [SerializeField] private AudioClip _clip;
    
    public UnityEvent player_DeathEvent;
    public UnityEvent on_player_hit;

    void Start()
    {
        PowerupManager powerupManager_script = _PowerupManager.GetComponent<PowerupManager>();
        powerupManager_script.powerup_obtained.AddListener(add_player_health);
        
    }
    
    void Update()
    {
        transform.position = player_camera.transform.position;
    }

    public void player_hit(){
        player_health -= 1;
        on_player_hit.Invoke();
        SoundManager.Instance.PlaySound(_clip);
        // UIHearts UIHeartsScript = player.GetComponent<Player>();
        check_player_health();
    }

    private void check_player_health(){
        if (player_health <= 0){
            player_DeathEvent.Invoke();
        }
    }

    private void add_player_health() {
        if (player_health < 5) {
            player_health += 1;
        }
    }
   
}
