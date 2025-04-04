using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float damage = 2f; // daño

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthControl health = other.GetComponent<HealthControl>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
