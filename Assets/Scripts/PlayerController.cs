using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float groundDist = 0.5f;
    public Rigidbody rb;
    public Transform groundPoint;
    private bool isGrounded;
    public Animator animator;

    // Movimiento
    private Vector2 moveInput;
    private Vector2 lastMoveDirection = Vector2.right; // Dirección inicial hacia la derecha
    public float normalGravity;
    public float AbGravity;

    // Respawn y Render
    public LayerMask groundMask;
    public Transform Respawn;
    public SpriteRenderer spriteRenderer;

    // Habilidad
    public float maxGlideTime = 0.5f;
    private float glideTime = 0f;
    private bool canGlide = true;

    //animacion disparo
    private bool hasWeapon = false;
    private bool isShooting = false;

    


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void Update()
    {
        // Capturar movimiento del jugador
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        if (moveInput.magnitude > 0.1f)  // Si el jugador se está moviendo
        {
            lastMoveDirection = moveInput.normalized; // Guardar última dirección de movimiento
        }

        rb.velocity = new Vector3(moveInput.x * speed, rb.velocity.y, moveInput.y * speed);
        Animation();

        isGrounded = Physics.Raycast(groundPoint.position, Vector3.down, groundDist, groundMask); //verificar qye esta en el suelo


        //Salto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
            animator.SetBool("Jumping", true);
            Debug.Log("entrando de animacion de salto");
            StartCoroutine(ResetJumpAnimation());
            
        }
        

        // Manejo de gravedad
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity += Vector3.down * AbGravity * Time.deltaTime;
            glideTime += Time.deltaTime;
            if (glideTime >= maxGlideTime)
            {
                canGlide = false;
            }
            animator.SetBool("Gliding", true);
        }
        else
        {
            rb.velocity += Vector3.down * normalGravity * Time.deltaTime;
            animator.SetBool("Gliding", false);
        }

        // Voltear sprite según dirección
        if (moveInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }

        if (hasWeapon && Input.GetKeyDown(KeyCode.E) && !isShooting) //animacion disparo de personaje 
        {
            //animator.SetTrigger("Shooting"); //(no funciono)
            //animator.SetBool("Shooting", true);
            StartCoroutine(ShootAnimation());
        }



    }



    void Animation()
    {
        //animacion lateral
        bool isWalkingX = moveInput.x != 0;
        animator.SetBool("WalkingL", isWalkingX);

        //animacion frente y trasera
        bool isWalkingForward = moveInput.y < 0;
        bool isWalkingBackward = moveInput.y > 0;

        animator.SetBool("WalkingF", isWalkingForward);
        animator.SetBool("WalkingB", isWalkingBackward);

        /*
        if (moveInput.x != 0)
        {
            animator.SetBool("WalkingL", true);
        }
        else
        {
            animator.SetBool("WalkingL", false);
        }
        */

    }

    public void PickUpWeapon()
    {
        hasWeapon = true;
    }

    private System.Collections.IEnumerator ShootAnimation()
    {
        /*
        yield return new WaitForSeconds(0.5f); // tiempo de animacion 
        animator.SetBool("Shooting", false);
        Debug.Log("Saliendo de animacion de disparo");
       */

        isShooting = true;
        animator.SetTrigger("Shooting");
        yield return new WaitForSeconds(0.5f); // tiempo de animacion
        isShooting = false;
        
    }
    private System.Collections.IEnumerator ResetJumpAnimation()
    {
        yield return new WaitForSeconds(0.26f); // tiempo de animacion 
        if (isGrounded)
        {
            animator.SetBool("Jumping", false);
            Debug.Log("Saliendo de animacion de salto");
        }
    }

    public void RespawnPlayer()
    {
        transform.position = Respawn.position;
    }

   
}




