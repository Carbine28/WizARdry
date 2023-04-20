using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;

    private void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider col)
{
    print(col);
    if (col.CompareTag("Player"))
    {
        print("Enemy Destroyed");
        Destroy(gameObject);
    }
}
}
