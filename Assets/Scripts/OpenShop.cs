using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenShop : MonoBehaviour
{
    private GameObject shop;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //int currentLevel = SceneManager.GetActiveScene().buildIndex; // Obtiene el nivel actual

        shop = GameObject.Find("ShopCanvas");

        //if (currentLevel < 6)
        //{
            shop.SetActive(false); // La tienda no aparece antes del nivel 3
            Destroy(gameObject); // Elimina el objeto de la tienda en niveles inferiores
        //}
        //else
       // {
        //    shop.SetActive(false);
        //}

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
