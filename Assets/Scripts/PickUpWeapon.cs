using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{

    public int ammoGiven;
    public GameObject tapeWUI;
    //public int noooo;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Tag para que sea el jugador que lo toque
        {
            TapeWeapon weapon = other.GetComponentInChildren<TapeWeapon>(); // encuentre el script del arma
            if (weapon != null)
            {
                weapon.PickUpWeapon();
                weapon.AddAmmo(ammoGiven);

                if (tapeWUI != null)
                {
                    tapeWUI.SetActive(true); // Activa la UI del arma
                }
                gameObject.SetActive(true);
                Debug.Log("Arma recogida: Tape Weapon"); 
                Destroy(gameObject);
            }
            
        }
    }
}
