using TMPro;
using UnityEngine;

public class tapeWeaponForward : MonoBehaviour
{
    [Header ("Settings Viewer")]
    public GameObject tapePrefab;
    public Transform firepoint;
    public float bulletSpeed = 10f;
    private bool hasWeapon = false;
    public SpriteRenderer playerSprite;
    public Animator weaponAnimator; // Agregar Animator para el arma

    [Header("Settings Weapon")]
    public int ammoCount = 15; //disparos disponibles
    public TextMeshProUGUI tapeAText;
    public GameObject tapeWUI;

    private void Start()
    {

        if (tapeWUI != null)
        {
            tapeWUI.SetActive(false);
        }
        if (tapeAText != null)
        {
            tapeAText.gameObject.SetActive(false); // Ocultar el texto de munici�n al inicio
        }
        UpdateUI();

        Debug.Log("Tape Weapon en: " + gameObject.scene.name + "posicion: " + transform.position);


    }

    public void PickUpWeapon()
    {
        hasWeapon = true;

        if (tapeAText != null) //poner texto del arma
        {
            tapeAText.gameObject.SetActive(true);
        }
        if (tapeWUI != null) //poner la imagen del arma
        {
            tapeWUI.SetActive(true);
        }
        gameObject.SetActive(true);
        UpdateUI(); //se llama a funcion para que se actualice la ui
    }

    public void AddAmmo(int amount)
    {
        ammoCount += amount;
        //info de cuantas tienes
    }

    void Update() //boton para disparar
    {
        if (hasWeapon && ammoCount > 0 && Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }
    }

    void Shoot()
    {

        if (ammoCount <= 0) //por si queda sin municion
        {
            Debug.Log("Sin munici�n. Compra m�s en la tienda.");
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
                bulletRB.velocity = firepoint.forward * bulletSpeed;
            }


        }
    }
    public bool BuyTapeAmmo(UIPrincipio uiPrincipio, int cost, int amount)
    {
        if (uiPrincipio.springs >= cost)
        {
            uiPrincipio.springs -= cost;
            AddAmmo(amount);
            PickUpWeapon();
            gameObject.SetActive(true);
            return true;
        }
        return false;
    }

    private void UpdateUI()
    {
        if (tapeAText != null)
        {
            tapeAText.text = "" + ammoCount; //mantener actualizado el texto con el ammo amount
        }
    }
}
