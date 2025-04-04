using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenShop : MonoBehaviour
{
    [Header ("ShopCanvas")]
    public GameObject shop;

    
    void Start()
    {

        shop = GameObject.Find("ShopCanvas");
        if (shop != null)
        {
            shop.SetActive(false);
        }
        else
        {
            Debug.Log("No se asigno inspector");
        }
                    

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player" && shop != null)
        {
            shop.SetActive(true);
        }
        
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player" && shop != null)
        {
            shop.SetActive(false);
        }
    }
}
