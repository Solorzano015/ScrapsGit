using UnityEngine;

public class Trap : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter(Collider other)
    {

        HealthControl healthControl = FindAnyObjectByType<HealthControl>();
        healthControl.health += damage;

    }
}
