using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class IntEvent : UnityEvent<int> {}

public class Enemy : MonoBehaviour
{
    public IntEvent enemyDefeated;

    private void OnTriggerEnter(Collider col){   

        if(col.CompareTag("Projectile")){
            enemyDefeated.Invoke(100);
            Destroy(gameObject);
        } 
        if (col.CompareTag("Player"))
        {}
            Player playerScript = col.gameObject.GetComponent<Player>();
            playerScript.player_hit();
            enemyDefeated.Invoke(-50);
            Destroy(gameObject);
        }
}
