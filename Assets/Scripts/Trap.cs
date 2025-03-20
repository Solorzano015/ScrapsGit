using UnityEngine;

public class Trap : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter(Collider other)
    {

        HealthControl healthControl = other.GetComponent<HealthControl>();
        if (healthControl != null)
        {
            healthControl.health -= damage;
            Debug.Log("vida del jugador:" + healthControl.health);
        }

    }
}
