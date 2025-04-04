using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage =1f;  // Da�o
    public float lifeTime = 3f;  // Tiempo antes de que la bala se destruya autom�ticamente

    void Start()
    {
        Destroy(gameObject, lifeTime);  // Destruir la bala en un tiempo
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // Verifica si golpe� a un enemigo
        {
        Debug.Log("Bala impact� al enemigo.");
        EnemyG enemy = other.GetComponent<EnemyG>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Debug.Log($"Disparo impact� en {other.gameObject.name}, causando {damage} de da�o");
            }

            Destroy(gameObject); // Destruye la bala al impactar
        }
    }
}
