using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Points : MonoBehaviour
{

    
    private int numNeedles = 0;
    private int numTapes = 0;

    private int costNeedles = 2;
    private int costTapes = 1;

    [Header("Scripts")]
    public tapeWeaponForward tapeWeapon;
    public NeedleWeapon needleWeapon;

    [Header ("UI de tienda")]
    public TextMeshProUGUI infoBuyText;
    public UIPrincipio uiPrincipio;

    

    private void Start()
    {
        if (uiPrincipio == null)
        {
            uiPrincipio = FindAnyObjectByType<UIPrincipio>();
        }
        if (tapeWeapon == null)
        {
            tapeWeapon = FindAnyObjectByType<tapeWeaponForward>();
        }

        if (needleWeapon == null)
        {
            needleWeapon = FindAnyObjectByType<NeedleWeapon>();
        }
    }
    
    public void buyNeedle()
    {
        if (needleWeapon.BuyNeedleAmmo(uiPrincipio, costNeedles, 2))
        {
            numNeedles += 2;
            infoBuyText.text = numNeedles + " Buyed Needle/s and " + uiPrincipio.springs + " Springs left";
        }
        else
        {
            infoBuyText.text = "Not enough Springs! Find more Please";
        }
    }
    public void buyTape()
    {
        if (tapeWeapon.BuyTapeAmmo(uiPrincipio, costTapes, 3))
        {
            numTapes += 3;
            infoBuyText.text = numTapes + " Buyed Tape/s and " + uiPrincipio.springs + " Springs left";
        }
        else
        {
            infoBuyText.text = "Not enough Springs! Find more Please";
        }
    }
}
