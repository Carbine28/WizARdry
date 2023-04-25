using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    private void OnTriggerEnter(Collider col){   
        if (col.CompareTag("Player"))
        {
            Player playerScript = col.gameObject.GetComponent<Player>();
            playerScript.player_hit();
            Destroy(gameObject);
        }
    }

}
