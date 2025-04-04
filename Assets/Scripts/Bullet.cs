using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage =1f;  // Daño
    public float lifeTime = 3f;  // Tiempo antes de que la bala se destruya automáticamente

    void Start()
    {
        Destroy(gameObject, lifeTime);  // Destruir la bala en un tiempo
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // Verifica si golpeó a un enemigo
        {
        Debug.Log("Bala impactó al enemigo.");
        EnemyG enemy = other.GetComponent<EnemyG>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Debug.Log($"Disparo impactó en {other.gameObject.name}, causando {damage} de daño");
            }

            Destroy(gameObject); // Destruye la bala al impactar
        }
    }
}
