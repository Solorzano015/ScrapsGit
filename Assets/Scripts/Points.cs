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
    
    public void buyNeedle()
    {
        if (uiPrincipio.springs >= costNeedles)
        {
            numNeedles += 2;
            uiPrincipio.springs -= costNeedles;
            infoBuyText.text =  numNeedles + "Buyed Needle/s and" + uiPrincipio.springs + "Springs left";

            needleWeapon.needlePrefab = Resources.Load<GameObject>("NeedleBullet");

            if (needleWeapon != null)
            {
                needleWeapon.needlePrefab = Resources.Load<GameObject>("NeedleBullet");
                needleWeapon.AddAmmo(2); // Por ejemplo, añade 5 disparos
                needleWeapon.PickUpWeapon();
            }
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
            numTapes += 3;
            uiPrincipio.springs -= costTapes;
            infoBuyText.text = numTapes + "Buyed Tape/s and" + uiPrincipio.springs + "Springs left";

            tapeWeapon.tapePrefab = Resources.Load<GameObject>("TapeBullet");

            if (tapeWeapon != null)
            {
                tapeWeapon.tapePrefab = Resources.Load<GameObject>("TapeBullet");
                tapeWeapon.AddAmmo(3); // Por ejemplo, añade 5 disparos
                tapeWeapon.PickUpWeapon();
            }

        }
        else
        {
            infoBuyText.text = "Not enough Springs! Find more Please";
        }
    }
}
