using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class HeartPowerup : MonoBehaviour
{
    // [SerializeField] private AudioClip spawn_clip;
    [SerializeField] private AudioClip hit_clip;
    public Transform player;
    public float rotationX = 270f;
    public float rotationY = 0f;
    public float rotationZ = 90f;
    public UnityEvent heartHit;

    private void Start(){
        // SoundManager.Instance.PlaySound(spawn_clip);
        // _modelTransform = transform.GetChild(0);
        transform.Rotate(rotationX, rotationY, rotationZ);
    }

    private void Update() {
        transform.LookAt(player); // Rotate model to look at player
    }

    private void OnTriggerEnter(Collider col){   

        if(col.CompareTag("Projectile")){
            SoundManager.Instance.PlaySound(hit_clip);
            heartHit.Invoke();
            Destroy(gameObject);
        } 
    }

}
