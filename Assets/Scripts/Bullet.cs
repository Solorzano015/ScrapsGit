using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 1f;  // Daño
    public float lifeTime = 3f;  // Tiempo antes de que la bala se destruya automáticamente

    void Start()
    {
        Destroy(gameObject, lifeTime);  // Destruir la bala en un tiempo
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si golpea a un enemigo
        EnemyG enemy = other.GetComponent<EnemyG>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);  // Restar vida al enemigo
            Destroy(gameObject);  // Destruir la bala
        }
    }
}
