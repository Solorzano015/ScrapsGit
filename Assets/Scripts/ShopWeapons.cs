using TMPro;
using UnityEngine;

public class ShopWeapons : MonoBehaviour
{
    [Header("UI")]
    public UIPrincipio uiPrincipio;
    public TextMeshProUGUI infoBuyText;

    [Header("Scripts")]
    public NeedleWeapon needleWeapon;
    public tapeWeaponForward tapeWeapon;

    

    [Header("Costos y cantidades")]
    public int needleAmmoCost = 2;
    public int needleAmmoAmount = 0;

    public int tapeAmmoCost = 1;
    public int tapeAmmoAmount = 5;

    // Llamar esta función desde el botón para comprar agujas
    public void BuyNeedle()
    {
        if (needleWeapon != null && uiPrincipio != null)
        {
            bool success = needleWeapon.BuyNeedleAmmo(uiPrincipio, needleAmmoCost, needleAmmoAmount);
            if (success)
                infoBuyText.text = needleAmmoAmount + " Buyed Needle/s and " + uiPrincipio.springs + " Springs left";
            else
                infoBuyText.text = "Not enough Springs! Find more Please";
        }
    }

    // Llamar esta función desde el botón para comprar cinta
    public void BuyTape()
    {
        if (tapeWeapon != null && uiPrincipio != null)
        {
            bool success = tapeWeapon.BuyTapeAmmo(uiPrincipio, tapeAmmoCost, tapeAmmoAmount);
            if (success)
                infoBuyText.text = tapeAmmoAmount + " Buyed Tape/s and " + uiPrincipio.springs + " Springs left";
            else
                infoBuyText.text = "Not enough Springs! Find more Please";
        }
    }
}
