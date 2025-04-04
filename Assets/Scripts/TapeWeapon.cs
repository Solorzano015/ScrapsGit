using TMPro;
using UnityEngine;

public class TapeWeapon : MonoBehaviour
{
    public GameObject tapePrefab;
    public Transform firepoint;
    public float bulletSpeed = 10f;
    private bool hasWeapon = false;
    public SpriteRenderer playerSprite;
    public Animator weaponAnimator; // Agregar Animator para el arma

    public int ammoCount = 0; //disparos disponibles
    public TextMeshProUGUI tapeAText;

    public void PickUpWeapon()
    {
        hasWeapon = true;
        UpdateUI();
    }

    public void AddAmmo(int amount)
    {
        ammoCount+= amount;
        //info de cuantas tienes
    }

    void Update()
    {
        if (hasWeapon && ammoCount > 0 && Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }
    }

    void Shoot()
    {

        if (ammoCount <= 0)
        {
            Debug.Log("Sin munición. Compra más en la tienda.");
            return;
        }

        ammoCount--;
        UpdateUI();

        if (weaponAnimator != null)
        {
            weaponAnimator.SetTrigger("Shooting");
        }

        if (tapePrefab != null && firepoint != null)
        {
            GameObject bullet = Instantiate(tapePrefab, firepoint.position, firepoint.rotation);
            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();

            if (bulletRB != null)
            {
                bulletRB.useGravity = false;
                float direction = playerSprite.flipX ? -1f : 1f;
                bulletRB.velocity = new Vector3(direction * bulletSpeed, 0f, 0f);
            }
        }
    }

    private void UpdateUI()
    {
        if (tapeAText != null)
        {
            tapeAText.text = "" + ammoCount;
        }
    }
}
