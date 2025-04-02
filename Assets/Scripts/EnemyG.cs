using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering;

public class EnemyG : MonoBehaviour
{

    public float speed = 2f;
    public LayerMask obstacleLayer;
    private Vector3 direction = Vector3.right;

    // Vida del enemigo
    public float enemyHealth = 3f;
    public float maxEnemyHealth = 3f;

    void Start()
    {
        enemyHealth = maxEnemyHealth;
    }

    void Update()
    {
        // Mueve al enemigo en la dirección actual
        transform.position += direction * speed * Time.deltaTime;

        // Detecta si hay un obstáculo adelante
        if (Physics.Raycast(transform.position, direction, 0.6f, obstacleLayer))
        {
            direction *= -1; // Cambia la dirección si hay un obstáculo
        }
    }

    public void TakeDamage(float amount)
    {
        enemyHealth -= amount;
        if (enemyHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject); // Eliminar el enemigo
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + direction * 0.6f);
    }


}

