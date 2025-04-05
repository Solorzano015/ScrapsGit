using System.Collections.Generic;
using UnityEngine;

public class BossFinal : MonoBehaviour
{
    public float speed = 7f;
    public LayerMask obstacleLayer;
    private Vector3 direction = Vector3.right;

    // Vida del enemigo
    public float enemyBHealth = 8f;
    public float maxEnemyHealth = 8f;


    //disparo 
    public GameObject BossWeaponPrefab;
    public Transform firepoint;
    public float bulletSpeed = 30f;
    public float bulletLifetime = 20f;

    private Transform player;
    private List<Vector3> playerPositions = new List<Vector3>(); //almacenar la ultima posicion del jugador 

    void Start()
    {
        enemyBHealth = maxEnemyHealth;

        player = GameObject.FindGameObjectWithTag("Player")?.transform; //encuentre al jugador

        // para disparar cada 3 seg
        InvokeRepeating("ShootAtLastKnownPosition", 1f, 3f);
    }

    void Update()
    {

        transform.position += direction * speed * Time.deltaTime;

        // Detecta si hay un obstáculo adelante
        if (Physics.Raycast(transform.position, direction, 0.6f, obstacleLayer))
        {
            direction *= -1;
        }

        if (player != null)
        {
            // Guardar posición actual del jugador/frame
            playerPositions.Add(player.position);

            // Limitar tamaño de almacenado
            if (playerPositions.Count > 10)
            {
                playerPositions.RemoveAt(0);
            }
        }
    }

    void ShootAtLastKnownPosition()
    {
        if (playerPositions.Count < 2) return; // al menos dos posiciones

        Vector3 targetPos = playerPositions[playerPositions.Count - 2]; //  penúltima posición (mas sencillo)

        for (int i = 0; i < 4; i++)
        {
            GameObject bullet = Instantiate(BossWeaponPrefab, firepoint.position, Quaternion.identity);
            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();

            if (bulletRB != null)
            {
                bulletRB.useGravity = false;
                Vector3 direction = (targetPos - firepoint.position).normalized;
                bulletRB.velocity = direction * bulletSpeed;
            }

            BossBullet bossBullet = bullet.GetComponent<BossBullet>();
            if (bossBullet != null)
            {
                bossBullet.damage = 1f; // Puedes ajustar esto
            }

            Destroy(bullet, bulletLifetime); // destruir después de X segundos
        }
    }

    public void TakeDamage(float amount)
    {
        enemyBHealth -= amount;
        if (enemyBHealth <= 0)
        {
            DieBoss();
        }
    }

    void DieBoss()
    {
        
        Destroy(gameObject);
    }
}
