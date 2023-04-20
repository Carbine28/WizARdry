using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private void OnTriggerEnter(Collider col){   
        if (col.CompareTag("Enemy"))
        {
            Destroy(col.gameObject);
        }
    }
}
