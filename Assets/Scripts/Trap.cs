using UnityEngine;

public class Trap : MonoBehaviour
{
    public int damage;
    float pushForce = 5f;

    private void OnTriggerEnter(Collider other)
    {

        HealthControl healthControl = other.GetComponent<HealthControl>();
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (healthControl != null)
        {
            healthControl.TakeDamage(damage);
            Debug.Log("vida del jugador:" + healthControl.health);

            if (rb != null)
            {
                Vector3 pushDirection = (other.transform.position - transform.position).normalized;
                pushDirection.y = 0;
                rb.AddForce(pushDirection* pushForce, ForceMode.Impulse);
            }

        }

    }
}
