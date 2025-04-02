using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Weapon weapon = other.GetComponent<Weapon>();
        if (weapon != null)
        {
            weapon.PickUpWeapon();
            Destroy(gameObject);
        }
    }
}
