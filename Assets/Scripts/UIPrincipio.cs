using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIPrincipio : MonoBehaviour
{
    public int springs = 0;

    public HealthControl healthPlayer;


    public TextMeshProUGUI healthText;
    public TextMeshProUGUI springsText;

   

    private void Start()
    {
        healthPlayer.health = healthPlayer.MaxHealth;
        UpdateHealthUI();
        UpdateSpringsUI();
    }

    private void Update()
    {
        UpdateHealthUI();
    }
    private void UpdateHealthUI()
    {
        healthText.text = healthPlayer.health.ToString() + "/" + healthPlayer.MaxHealth;
    }

    public void AddSpring(int amount)
    {
        springs += amount;
        UpdateSpringsUI();
    }


    private void UpdateSpringsUI()
    {
        springsText.text = "" + springs.ToString();
    }


}

