using UnityEngine;
using UnityEngine.UI;

public class BuyNeedleButton : MonoBehaviour
{
    public Points shopPoints;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(BuyNeedle);
    }

    void BuyNeedle()
    {
        if (shopPoints != null)
        {
            shopPoints.buyNeedle();
        }
    }
}
