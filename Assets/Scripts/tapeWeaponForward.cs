using TMPro;
using UnityEngine;

public class tapeWeaponForward : MonoBehaviour
{
    public GameObject tapePrefab;
    public Transform firepoint;
    public float bulletSpeed = 10f;
    private bool hasWeapon = false;
    public SpriteRenderer playerSprite;
    public Animator weaponAnimator; // Agregar Animator para el arma

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
            tapeAText.gameObject.SetActive(false); // Ocultar el texto de munición al inicio
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
            GameObject bullet = Instantiate(tapePrefab, firepoint.forward, firepoint.rotation);
            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();

            
        }
    }

    private void UpdateUI()
    {
        if (tapeAText != null)
        {
            tapeAText.text = "" + ammoCount; //mantener actualizado el texto con el ammo amount
        }
    }
}
