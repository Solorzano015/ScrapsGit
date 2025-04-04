using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapeWeapon : MonoBehaviour
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
        
        if (tapeAText != null)
        {
            tapeAText.gameObject.SetActive(true); // Ocultar el texto de munición al inicio
        }
        if (tapeWUI != null)
        {
            tapeWUI.SetActive(true);
        }
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
