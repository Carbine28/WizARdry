using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private GameObject player_camera;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        transform.position = player_camera.transform.position;
    }
}
