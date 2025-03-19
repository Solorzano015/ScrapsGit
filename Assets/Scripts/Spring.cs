using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spring : MonoBehaviour
{
    private int valor = 1;

    private void OnTriggerEnter(Collider other)
    {

        Points control = FindAnyObjectByType<Points>();
        control.springs += valor;
        control.PointText.text = "" + control.springs;
        Destroy(gameObject);

    }
}
