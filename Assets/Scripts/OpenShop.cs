using UnityEngine;

public class OpenShop : MonoBehaviour
{
    private GameObject shop;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        shop = GameObject.Find("ShopCanvas");
        shop.SetActive(false);

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            shop.SetActive(true);
        }
        
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            shop.SetActive(false);
        }
    }
}
