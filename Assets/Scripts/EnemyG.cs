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

    //animacion
    public Animator animator;
    //private bool isAttacking = false;
    //private float attackDuration = 0.5f; // Duración de la animación de ataque
    //private float attackTimer = 0f;

    void Start()
    {
        enemyHealth = maxEnemyHealth;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        /* //no funciono con amnimacion enemigo
        if (isAttacking)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackDuration)
            {
                isAttacking = false;
                animator.SetBool("Attacking", false); // Desactivar animación después del tiempo
            }
        }
        else
        {
            // Mueve al enemigo en la dirección actual solo si no está atacando
            transform.position += direction * speed * Time.deltaTime;

            // Detecta si hay un obstáculo adelante
            if (Physics.Raycast(transform.position, direction, 0.6f, obstacleLayer))
            {
                direction *= -1;
            }
        }
        */
        // Mueve al enemigo en la dirección actual
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attacking"))
        {
            transform.position += direction * speed * Time.deltaTime;
        }
        

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

    public void BoolAttack()
    {
        Debug.Log("Esta atacando el enemigo");
        //isAttacking = true;
        //attackTimer = 0f;
        //animator.SetBool("Attacking", true);
        animator.SetTrigger("Attacking");
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + direction * 0.6f);
    }


}

