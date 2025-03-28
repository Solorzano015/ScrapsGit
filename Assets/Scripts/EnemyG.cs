using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class EnemyG : MonoBehaviour
{

    public float speed;  // Velocidad del enemigo
    public LayerMask obstacleLayer;  // Capa para detectar los obst�culos

    private Vector3 direction = Vector3.right; // Comienza movi�ndose a la derecha

    void Update()
    {
        // Mueve al enemigo en la direcci�n actual
        transform.position += direction * speed * Time.deltaTime;

        // Detecta si hay un obst�culo adelante usando un Raycast
        if (Physics.Raycast(transform.position, direction, 0.6f, obstacleLayer))
        {
            direction *= -1; // Cambia la direcci�n si hay un obst�culo
        }
    }

    
    void OnDrawGizmos()
    {
        // Dibuja una l�nea en la escena para visualizar el Raycast
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + direction * 0.6f);
    }

    /*
    public float speed = 3f;
    private int direction = 1; // 1 para derecha, -1 para izquierda

    void Update()
    {
        // Mover el enemigo en la direcci�n actual
        transform.position += Vector3.right * direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Cuando choca, cambia de direcci�n
        direction *= -1;
    }
    */


}

