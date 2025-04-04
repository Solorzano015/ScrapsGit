using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject needleWeapon;
    public GameObject tapeWeapon;

    private int currentWeaponIndex = 1;
    private GameObject[] weapons;

    void Start()
    {
        weapons = new GameObject[] { needleWeapon, tapeWeapon };
        ActivateWeapon(currentWeaponIndex);
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll > 0f)
        {
            currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Length;
            ActivateWeapon(currentWeaponIndex);
        }
        else if (scroll < 0f)
        {
            currentWeaponIndex = (currentWeaponIndex - 1 + weapons.Length) % weapons.Length;
            ActivateWeapon(currentWeaponIndex);
        }
    }

    void ActivateWeapon(int index)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            bool isActive = (i == index);
            weapons[i].SetActive(isActive);
        }

        Debug.Log("Arma activa: " + weapons[index].name);
    }
}
