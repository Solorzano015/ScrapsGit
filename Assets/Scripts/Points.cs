using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public int springs= 0;

    public HealthControl healthPlayer;
    

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI PointText;

    //shop variables
    private int numNeedles = 0;
    private int numTapes = 0;

    private int costNeedles = 2;
    private int costTapes = 1;

    public TextMeshProUGUI infoBuyText;

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
    public void buyNeedle()
    {
        if (springs >= costNeedles)
        {
            numNeedles ++;
            springs -= costNeedles;
            infoBuyText.text =  numNeedles + "Buyed Needle/s and" + springs + "Springs left";
        }
        else
        {
            infoBuyText.text = "Not enough Springs! Find more Please";
        }
    }
    public void buyTape()
    {
        if (springs >= costTapes)
        {
            numTapes++;
            springs -= costTapes;
            infoBuyText.text = numTapes + "Buyed Tape/s and" + springs + "Springs left";
        }
        else
        {
            infoBuyText.text = "Not enough Springs! Find more Please";
        }
    }
}
