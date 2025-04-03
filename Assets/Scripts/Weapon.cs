using UnityEngine;
using UnityEngine.SceneManagement;

public class Weapon : MonoBehaviour
{
    public static Weapon instance;


    //Tape Weapon
    public GameObject tapePrefab;
    public Transform firepoint;
    public float bulletSpeed = 10f;
    private bool hasWeapon = false;

    //Weapon general
    public SpriteRenderer playerSprite;
    private bool canShoot = true;
    public float shootCooldown = 0.5f;

    private GameObject currentWeapon;
    private int currentWeaponIndex = 0; //0 = tape, 1= needle
    private GameObject[] bullets; //almacenar balas disponibles

    //Needle Weapon
    public GameObject needlePrefab;
    private bool hasNeedle = false;



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
    public void Start()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex; // Obtiene el nivel actual

        // Solo agregar la aguja si el nivel es 3 o superior
        if (currentLevel >= 6)
        {
            bullets = new GameObject[] { tapePrefab, needlePrefab }; // Ambas balas disponibles
        }
        else
        {
            bullets = new GameObject[] { tapePrefab }; // Solo la Tape
        }

        if (PlayerPrefs.GetInt("HasWeapon", 0) == 1)
        {
            hasWeapon = true;
        }
    }

    public void PickUpWeapon()
    {
        hasWeapon = true;
        PlayerPrefs.SetInt("HasWeapon", 1);
        PlayerPrefs.Save();
    }

    public void NeedleWeapon()
    {
        hasNeedle = true;
        PlayerPrefs.SetInt("HasNeedleWeapon", 1);
        PlayerPrefs.Save();
    }

    void Update()
    {
        if (hasWeapon)
        {
            if (Input.GetKeyDown(KeyCode.E) && canShoot)
            {
                Shoot();
            }

            // Cambiar entre balas con la rueda del ratón
            if (Input.GetAxis("Mouse ScrollWheel") > 0f) // Rueda arriba
            {
                SwitchBullet(1);
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // Rueda abajo
            {
                SwitchBullet(-1);
            }
        }
    }

    public void Shoot()
    {
        if (bullets[currentWeaponIndex] != null && firepoint != null)
        {
            StartCoroutine(ShootCooldown());
            GameObject bullet = Instantiate(bullets[currentWeaponIndex], firepoint.position, firepoint.rotation);
            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();

            if (bulletRB != null)
            {
                bulletRB.useGravity = false;
                float direction = playerSprite.flipX ? -1f : 1f;
                bulletRB.velocity = new Vector3(direction * bulletSpeed, 0f, 0f);
            }
        }
    }
    private void SwitchBullet(int direction)
    {
        currentWeaponIndex += direction;

        if (currentWeaponIndex >= bullets.Length) currentWeaponIndex = 0;
        if (currentWeaponIndex < bullets.Length) currentWeaponIndex = bullets.Length -1;

        //Aqui poner como lo mostrara en la UI
        

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
