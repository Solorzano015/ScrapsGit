using TMPro;
using UnityEngine;

public class NeedleWeapon : MonoBehaviour
{
    

    public GameObject needlePrefab;
    public Transform firepoint;
    public float bulletSpeed = 10f;
    private bool hasWeapon = false;
    public SpriteRenderer playerSprite;
    public Animator weaponAnimator; // Agregar Animator para el arma

    public int ammoCount = 0; //disparos disponibles
    public TextMeshProUGUI needleAText;
    public GameObject needleWUI;
    private void Start()
    {

        if (needleWUI != null)
        {
            needleWUI.SetActive(false);
        }
        if (needleAText != null)
        {
            needleAText.gameObject.SetActive(false); // Ocultar el texto de munición al inicio
        }
        UpdateUI();

        Debug.Log("Needle Weapon en: " + gameObject.scene.name + "posicion: " + transform.position);


    }

    public void PickUpWeapon()
    {
        hasWeapon = true;

        if (needleAText != null)
        {
            needleAText.gameObject.SetActive(true); // Ocultar el texto de munición al inicio
        }
        UpdateUI();
    }

    public void AddAmmo(int amount)
    {
        ammoCount += amount;
        //info de cuantas tienes
    }

    void Update()
    {
        if (hasWeapon && ammoCount > 0 && Input.GetKeyDown(KeyCode.E))
        {
            ShootNeedle();
        }
    }

    void ShootNeedle()
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

        if (needlePrefab != null && firepoint != null)
        {
            GameObject bullet = Instantiate(needlePrefab, firepoint.position, firepoint.rotation);
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
        if (needleAText != null)
        {
            needleAText.text = "" + ammoCount;
        }
    }

   
}
