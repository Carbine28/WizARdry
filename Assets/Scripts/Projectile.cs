using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private Transform _modelTransform;
    public float rotationSpeed = 100f;

    public Vector3 movementDirection;
    public float projectile_speed = 5.0f;

    public float max_distance = 40f;

    private void Start(){
        _modelTransform = transform.GetChild(0);
    }

    private void Update(){

        // float angle = rotationSpeed * Time.deltaTime;
        // float x = Mathf.Cos(angle);
        // float z = Mathf.Sin(angle);
        // _modelTransform.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime, Space.Self);
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime, Space.World);
        // _modelTransform.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self);
        // Move the projectile in its movement direction
        transform.position += movementDirection * projectile_speed * Time.deltaTime;


        float distanceFromOrigin = Vector3.Distance(transform.position, Vector3.zero);
        if ( distanceFromOrigin > max_distance){
            Destroy(gameObject);
        }
        // float angle = Time.time * rotationSpeed;
        // float x = Mathf.Cos(angle);
        // float z = Mathf.Sin(angle);
        // transform.localPosition = new Vector3(x, 0, z);
        // transform.LookAt(Vector3.zero);
    }

    private void OnTriggerEnter(Collider col){   
        if (col.CompareTag("Enemy"))
        {
            Destroy(col.gameObject);
            // If projectile isnt piercing then it destroys itself too
            
        }
    }
}
