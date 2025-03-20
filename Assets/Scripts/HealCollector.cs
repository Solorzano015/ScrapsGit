using UnityEngine;

public class HealCollector : MonoBehaviour
{
    private int valor = 1;

    private void OnTriggerEnter(Collider other)
    {

        HealthControl healthcontrol = FindAnyObjectByType<HealthControl>();
        healthcontrol.health += valor;
        if (healthcontrol.health > healthcontrol.MaxHealth)
        {
            healthcontrol.health = healthcontrol.MaxHealth;
        } 
        Destroy(gameObject);

    }
}
