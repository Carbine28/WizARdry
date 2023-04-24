using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider col){   
        if (col.CompareTag("Spell"))
        {
            col.gameObject.transform.parent.parent.GetComponent<Spell>().check_collision(col.gameObject);
        }
    }

    
}
