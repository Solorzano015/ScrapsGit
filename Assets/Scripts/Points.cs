using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Points : MonoBehaviour
{
   
    //shop variables
    private int numNeedles = 0;
    private int numTapes = 0;

    private int costNeedles = 2;
    private int costTapes = 1;

    public TextMeshProUGUI infoBuyText;
    public TapeWeapon tapeWeapon;
    public NeedleWeapon needleWeapon;

    public UIPrincipio uiPrincipio;

    private void Start()
    {
        if (uiPrincipio == null)
        {
            uiPrincipio = FindAnyObjectByType<UIPrincipio>();
        }
    }
    private void UpdateHealthUI()
    {
        //int currentLevel = SceneManager.GetActiveScene().buildIndex; // Obtiene el nivel actual

        //if (currentLevel < 6)
       // {
         //   needleText.gameObject.SetActive(false); // Oculta el texto de las Needles
       // }

       
    }
    public void buyNeedle()
    {
        if (uiPrincipio.springs >= costNeedles)
        {
            numNeedles ++;
            uiPrincipio.springs -= costNeedles;
            infoBuyText.text =  numNeedles + "Buyed Needle/s and" + uiPrincipio.springs + "Springs left";

            needleWeapon.needlePrefab = Resources.Load<GameObject>("NeedleBullet");
        }
        else
        {
            infoBuyText.text = "Not enough Springs! Find more Please";
        }
    }
    public void buyTape()
    {
        if (uiPrincipio.springs >= costTapes)
        {
            numTapes++;
            uiPrincipio.springs -= costTapes;
            infoBuyText.text = numTapes + "Buyed Tape/s and" + uiPrincipio.springs + "Springs left";

            tapeWeapon.tapePrefab = Resources.Load<GameObject>("TapeBullet");

        }
        else
        {
            infoBuyText.text = "Not enough Springs! Find more Please";
        }
    }
}
