using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        TapeWeapon weapon = other.GetComponent<TapeWeapon>();
        if (weapon != null)
        {
            weapon.PickUpWeapon();
            Destroy(gameObject);
        }
    }
}
