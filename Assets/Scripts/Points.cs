using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Points : MonoBehaviour
{
    public int springs= 0;

    public HealthControl healthPlayer;
    

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI PointText;

    public TextMeshProUGUI tapeText;
    public TextMeshProUGUI needleText;

    //shop variables
    private int numNeedles = 0;
    private int numTapes = 0;

    private int costNeedles = 2;
    private int costTapes = 1;

    public TextMeshProUGUI infoBuyText;

    public Weapon playerWeapon;

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
        //int currentLevel = SceneManager.GetActiveScene().buildIndex; // Obtiene el nivel actual

        //if (currentLevel < 6)
       // {
         //   needleText.gameObject.SetActive(false); // Oculta el texto de las Needles
       // }

        healthPlayer.health = healthPlayer.MaxHealth;
        UpdateHealthUI();
    }
    public void buyNeedle()
    {
        if (springs >= costNeedles)
        {
            numNeedles ++;
            springs -= costNeedles;
            infoBuyText.text =  numNeedles + "Buyed Needle/s and" + springs + "Springs left";

            playerWeapon.needlePrefab = Resources.Load<GameObject>("NeedleBullet");
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

            playerWeapon.tapePrefab = Resources.Load<GameObject>("TapeBullet");

        }
        else
        {
            infoBuyText.text = "Not enough Springs! Find more Please";
        }
    }
}
