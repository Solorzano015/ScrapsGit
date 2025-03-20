using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public int springs= 0;

    public HealthControl healthPlayer;
    

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI PointText;

    private void Start()
    {
        healthPlayer.health = healthPlayer.MaxHealth;
        UpdateHealthUI();
    }

    private void Update()
    {
        UpdateHealthUI();
    }
    private void UpdateHealthUI()
    {
        healthText.text = healthPlayer.health.ToString() + "/" + healthPlayer.MaxHealth;
    }
}
