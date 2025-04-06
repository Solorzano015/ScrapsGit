using UnityEngine;

public class HealCollector : MonoBehaviour
{
    private int valor = 1;
    public AudioSource healSource;
    public AudioClip healSound;
    private void OnTriggerEnter(Collider other)
    {

        HealthControl healthcontrol = FindAnyObjectByType<HealthControl>();
        healthcontrol.health += valor;
        if (healSource != null && healSound != null)
        {
            healSource.PlayOneShot(healSound);
        }

        if (healthcontrol.health > healthcontrol.MaxHealth)
        {
            healthcontrol.health = healthcontrol.MaxHealth;
        } 
        Destroy(gameObject);

    }
}
