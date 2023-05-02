using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHearts : MonoBehaviour
{
    // [SerializeField] GameObject player;
    [SerializeField] public GameObject Heart1;
    [SerializeField] public GameObject Heart2;
    [SerializeField] public GameObject Heart3;
    [SerializeField] public GameObject Heart4;
    [SerializeField] public GameObject Heart5;
    [SerializeField] private int current_health;

    void Start() {
        current_health = 5;
    }


    public void change_UI_hearts(int player_health) {
        // Player PlayerScript = player.GetComponent<Player>();
        current_health = player_health;

                
        switch (current_health)
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
