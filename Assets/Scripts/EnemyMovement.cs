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
        transform.LookAt(player);
        transform.position += direction * moveSpeed * Time.deltaTime;

    }

}
