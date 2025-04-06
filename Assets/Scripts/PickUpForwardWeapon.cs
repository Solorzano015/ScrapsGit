using UnityEngine;

public class PickUpForwardWeapon : MonoBehaviour
{
    public int ammoGiven;
    public GameObject tapeWUI;
    //public int noooo;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Tag para que sea el jugador que lo toque
        {
            tapeWeaponForward weaponF = other.GetComponentInChildren<tapeWeaponForward>(); // encuentre el script del arma
            if (weaponF != null)
            {
                weaponF.PickUpWeapon();
                weaponF.AddAmmo(ammoGiven);

                if (tapeWUI != null)
                {
                    tapeWUI.SetActive(true); // Activa la UI del arma
                }

                Debug.Log("Arma recogida: Tape Weapon");
                Destroy(gameObject);
                gameObject.SetActive(true);
            }

        }
    }
}
