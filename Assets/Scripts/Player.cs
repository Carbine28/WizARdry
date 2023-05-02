using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{

    [SerializeField] private GameObject player_camera;
    public UIOnScreen UIOnScreen;

    // I would generally create a player health script
    [SerializeField] private int player_health = 5;
    [SerializeField] private AudioClip _clip;
    
    public UnityEvent player_DeathEvent;
    
    void Update()
    {
        transform.position = player_camera.transform.position;
    }

    public void player_hit(){
        player_health -= 1;
        SoundManager.Instance.PlaySound(_clip);
        // UIHearts UIHeartsScript = player.GetComponent<Player>();
        UIOnScreen.ChangeUiHearts(player_health);
        check_player_health();
    }

    private void check_player_health(){
        if (player_health <= 0){
            player_DeathEvent.Invoke();
        }
    }
   
}
