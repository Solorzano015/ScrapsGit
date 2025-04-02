using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firepoint;
    public float bulletSpeed = 10f;
    private bool hasWeapon = false;
    public SpriteRenderer playerSprite;

    public void PickUpWeapon()
    {
        hasWeapon = true; // El jugador ahora tiene el arma
    }

    void Update()
    {
        if (hasWeapon && Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null && firepoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();

            if (bulletRB != null)
            {
                bulletRB.useGravity = false;
                bulletRB.velocity = firepoint.right * bulletSpeed; // Dispara en la dirección que mira el firepoint

                float direction = playerSprite.flipX ? -1f : 1f;
                bulletRB.velocity = new Vector3 (direction *bulletSpeed, 0f, 0f);
            }
        }
    }
}
