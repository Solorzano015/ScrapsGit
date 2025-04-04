using UnityEngine;
using UnityEngine.UI;

public class BuyTapeButton : MonoBehaviour
{
    public Points shopPoints;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(BuyTape);
    }

    void BuyTape()
    {
        if (shopPoints != null)
        {
            shopPoints.buyTape();
        }
    }
}
