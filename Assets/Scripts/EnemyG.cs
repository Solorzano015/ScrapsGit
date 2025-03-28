using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class EnemyG : MonoBehaviour
{

    public float speed;  // Velocidad del enemigo
    public LayerMask obstacleLayer;  // Capa para detectar los obstáculos

    private Vector3 direction = Vector3.right; // Comienza moviéndose a la derecha

    void Update()
    {
        // Mueve al enemigo en la dirección actual
        transform.position += direction * speed * Time.deltaTime;

        // Detecta si hay un obstáculo adelante usando un Raycast
        if (Physics.Raycast(transform.position, direction, 0.6f, obstacleLayer))
        {
            direction *= -1; // Cambia la dirección si hay un obstáculo
        }
    }

    
    void OnDrawGizmos()
    {
        // Dibuja una línea en la escena para visualizar el Raycast
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + direction * 0.6f);
    }

    /*
    public float speed = 3f;
    private int direction = 1; // 1 para derecha, -1 para izquierda

    void Update()
    {
        // Mover el enemigo en la dirección actual
        transform.position += Vector3.right * direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Cuando choca, cambia de dirección
        direction *= -1;
    }
    */


}

