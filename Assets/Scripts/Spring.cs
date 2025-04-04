using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spring : MonoBehaviour
{
    public int valor = 1; // 1 resorte
    private bool isCollected = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCollected = true;
            UIPrincipio uiPrincipio = other.GetComponentInChildren<UIPrincipio>();

            if (uiPrincipio != null)
            {
                Debug.Log($"El jugador ha recogido un resorte en: {gameObject.name}");
                uiPrincipio.AddSpring(valor);
            }
            
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
