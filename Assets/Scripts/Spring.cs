using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class Spring : MonoBehaviour
{
    public int valor = 1; // 1 resorte
    private bool isCollected = false;

    public AudioClip SpringSound;
    ///public AudioSource SpringSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCollected = true;

            if (SpringSound != null)
            {
                AudioSource.PlayClipAtPoint(SpringSound, transform.position);
                //SpringSource.PlayOneShot(SpringSound);
            }



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
