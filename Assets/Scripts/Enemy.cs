using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    

    public UnityEvent enemyDefeated;

    private void OnTriggerEnter(Collider col){   
        if (col.CompareTag("Player"))
        {
            Player playerScript = col.gameObject.GetComponent<Player>();
            playerScript.player_hit();

            enemyDefeated.Invoke();

            Destroy(gameObject);
        }
    }

}
