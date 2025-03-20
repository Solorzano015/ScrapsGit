using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthControl : MonoBehaviour
{
    public float health =5;
    public float MaxHealth = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = MaxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(float amount)
    {
        health -= amount;   
        health = Mathf.Clamp(health, 0, MaxHealth);
        Debug.Log("Nueva vida: " + health);
    }
}
