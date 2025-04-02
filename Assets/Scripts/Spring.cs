using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spring : MonoBehaviour
{
    public int valor = 1; // 1 resorte

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            Points control = other.GetComponent<Points>();

            if (control != null) // Verificar que el Player tiene el script Points
            {
                control.springs += valor;
                control.PointText.text = control.springs.ToString();
                Destroy(gameObject);
            }
        }
    }
}
