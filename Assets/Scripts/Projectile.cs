using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private AudioClip _cast_clip;
     [SerializeField] private AudioClip hit_clip;
    
    private Transform _modelTransform;
    public float rotationSpeed = 100f;

    public Vector3 movementDirection;
    public float projectile_speed = 5.0f;

    public float max_distance = 40f;

    private void Start(){
        SoundManager.Instance.PlaySound(_cast_clip);
        _modelTransform = transform.GetChild(0);
    }

    private void Update(){
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime, Space.World);
        // Move the projectile in its movement direction
        transform.position += movementDirection * projectile_speed * Time.deltaTime;

        // Optimise performance of projectiles by removing them after a certain distance
        float distanceFromOrigin = Vector3.Distance(transform.position, Vector3.zero);
        if ( distanceFromOrigin > max_distance){
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider col){   
        if (col.CompareTag("Enemy"))
        {
            Destroy(col.gameObject);
            SoundManager.Instance.PlaySound(hit_clip);
            // If projectile isnt piercing then it destroys itself too
            
        }
    }
}
