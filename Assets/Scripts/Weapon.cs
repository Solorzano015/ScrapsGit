using UnityEngine;

public class Weapon : MonoBehaviour
{
    public static Weapon instance;

    public GameObject bulletPrefab;
    public Transform firepoint;
    public float bulletSpeed = 10f;
    private bool hasWeapon = false;
    public SpriteRenderer playerSprite;
    private bool canShoot = true;
    public float shootCooldown = 0.5f;

    /*
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    /* arma como prefs para que se mantenga en las demas escenas (no funciono)
    private void Start()
    {

        if(PlayerPrefs.GetInt("hasWeapon", 0)== 1)
        {
            hasWeapon = true;
        }
        
    }
    */

    public void PickUpWeapon()
    {
        hasWeapon = true;
        PlayerPrefs.SetInt("HasWeapon", 1);
        PlayerPrefs.Save();
    }

    void Update()
    {
        if (hasWeapon && Input.GetKeyDown(KeyCode.E) && canShoot)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (bulletPrefab != null && firepoint != null)
        {

            StartCoroutine(ShootCooldown());
            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();

            if (bulletRB != null)
            {
                bulletRB.useGravity = false;

                float direction = playerSprite.flipX ? -1f : 1f;
                bulletRB.velocity = new Vector3(direction * bulletSpeed, 0f, 0f);
            }

            
        }
    }

    private System.Collections.IEnumerator ShootCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }
}


/*
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

    public void Shoot()
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

*/
