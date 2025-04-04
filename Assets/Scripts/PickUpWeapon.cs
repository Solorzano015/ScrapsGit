using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegura que es el jugador
        {
            TapeWeapon weapon = other.GetComponentInChildren<TapeWeapon>(); // Busca en los hijos del jugador
            if (weapon != null)
            {
                weapon.PickUpWeapon();
                Debug.Log("Arma recogida: Tape Weapon");
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("El jugador no tiene un TapeWeapon adjunto.");
            }
        }
    }
}
