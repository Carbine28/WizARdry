using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{

    [SerializeField] private GameObject player_camera;
    [SerializeField] public GameObject Heart1;
    [SerializeField] public GameObject Heart2;
    [SerializeField] public GameObject Heart3;
    [SerializeField] public GameObject Heart4;
    [SerializeField] public GameObject Heart5;

    // I would generally create a player health script
    [SerializeField] public int player_health = 5;
    [SerializeField] private AudioClip _clip;
    
    public UnityEvent player_DeathEvent;
    
    void Update()
    {
        transform.position = player_camera.transform.position;
    }

    public void player_hit(){
        player_health -= 1;
        SoundManager.Instance.PlaySound(_clip);
        change_UI_hearts();
        check_player_health();
    }

    private void check_player_health(){
        if (player_health <= 0){
            player_DeathEvent.Invoke();
        }
    }


    public void change_UI_hearts() {
                
        switch (player_health)
        {
            case 0:
                Heart1.SetActive(false);
                Heart2.SetActive(false);
                Heart3.SetActive(false);
                Heart4.SetActive(false);
                Heart5.SetActive(false);
                break;
            case 1:
                Heart1.SetActive(true);
                Heart2.SetActive(false);
                Heart3.SetActive(false);
                Heart4.SetActive(false);
                Heart5.SetActive(false);
                break;
            case 2:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(false);
                Heart4.SetActive(false);
                Heart5.SetActive(false);
                break;
            case 3:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(true);
                Heart4.SetActive(false);
                Heart5.SetActive(false);
                break;
            case 4:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(true);
                Heart4.SetActive(true);
                Heart5.SetActive(false);
                break;
            case 5:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(true);
                Heart4.SetActive(true);
                Heart5.SetActive(true);
                break;
            default:
                break;
        }
    }
   
}
