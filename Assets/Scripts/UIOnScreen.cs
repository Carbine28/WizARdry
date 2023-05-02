using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIOnScreen : MonoBehaviour
{
    [SerializeField] public GameObject Heart1;
    [SerializeField] public GameObject Heart2;
    [SerializeField] public GameObject Heart3;
    [SerializeField] public GameObject Heart4;
    [SerializeField] public GameObject Heart5;
    [SerializeField] public TextMeshProUGUI WaveCounter;
    [SerializeField] public TextMeshProUGUI ScoreCounter;

    void Start() {
        ChangeUiHearts(5);
        ChangeUIWaves(1);
        ChangeUIScore(0);
    }


    public void ChangeUiHearts(int player_health) {
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

    public void ChangeUIWaves(int current_wave) {
        switch(current_wave)
        {
            case 1:
                WaveCounter.text = "WAVE: 1";
                break;
            case 2:
                WaveCounter.text = "WAVE: 2";
                break;
            case 3:
                WaveCounter.text = "WAVE: 3";
                break;
            case 4:
                WaveCounter.text = "WAVE: 4";
                break;
            case 5:
                WaveCounter.text = "WAVE: 5";
                break;

        }
    }
    
    public void ChangeUIScore(int current_score) {
        ScoreCounter.text = "SCORE: " + current_score;
    }
}
