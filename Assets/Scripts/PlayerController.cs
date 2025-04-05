using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.SpriteMask;

public class PlayerController : MonoBehaviour
{
    [Header("Para Movimiento")]
    public float speed;
    public float jumpForce;
    public float groundDist = 0.5f;
    public Rigidbody rb;
    public Transform groundPoint;
    private bool isGrounded;
    public Animator animator;

    [Header ("Movimiento")]
    private Vector2 moveInput;
    private Vector2 lastMoveDirection = Vector2.right; // Dirección inicial hacia la derecha
    public float normalGravity;
    public float AbGravity;

    [Header("Respawn/Render")]
    public LayerMask groundMask;
    public Transform Respawn;
    public SpriteRenderer spriteRenderer;

    [Header("Habilidad")]
    public float maxGlideTime = 0.5f;
    private float glideTime = 0f;
    private bool canGlide = true;

    [Header("Animacion Disparo")]
    private bool hasWeapon = false;
    private bool isShooting = false;


    [Header("Sonidos")]
    public AudioClip jumpSound;
    public AudioClip attackSound;
    public AudioClip glideSound;
    public AudioClip backgroundMusic;
    public AudioClip walkingSound;

    private AudioSource sfxSource;
    private AudioSource musicSource;
    private AudioSource walkingSource;

    
    private bool isGlideSoundPlaying = false;

    [Header("Salud")]
    public HealthControl healthControl;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

        sfxSource = gameObject.AddComponent<AudioSource>();
        musicSource = gameObject.AddComponent<AudioSource>();
        walkingSource = gameObject.AddComponent<AudioSource>();


        walkingSource.clip = walkingSound;
        walkingSource.loop = true;
        walkingSource.volume = 0.6f;

        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.volume = 0.5f;
        musicSource.Play(); //reproducir musica base
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

        bool isWalking = moveInput.magnitude > 0.1f && isGrounded;


        //walking sound 
        if (isWalking && !walkingSource.isPlaying)
        {
            walkingSource.Play();
        }
        else if (!isWalking && walkingSource.isPlaying)
        {
            walkingSource.Stop();
        }

        isGrounded = Physics.Raycast(groundPoint.position, Vector3.down, groundDist, groundMask); //verificar qye esta en el suelo


        //Salto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
            animator.SetBool("Jumping", true);
            Debug.Log("entrando de animacion de salto");
            StartCoroutine(ResetJumpAnimation());

            if (jumpSound != null) //sonido de saltar
            {
                sfxSource.PlayOneShot(jumpSound); //solo una vez
            }

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

            if (!isGlideSoundPlaying && glideSound != null) //sonido de habilidad
            {
                sfxSource.clip = glideSound;
                sfxSource.loop = true;
                sfxSource.Play();
                isGlideSoundPlaying = true;
            }
        }
        else
        {
            rb.velocity += Vector3.down * normalGravity * Time.deltaTime;
            animator.SetBool("Gliding", false);
            if (isGlideSoundPlaying)
            {
                sfxSource.Stop();
                isGlideSoundPlaying = false;
            }
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

        if (hasWeapon && (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E)) && !isShooting) //para las dos animaciones, aguja y cinta
        {
            StartCoroutine(ShootAnimation());
        }

        if (healthControl != null && healthControl.health <= 0 && musicSource.isPlaying)// llama a funcion para que fadeout la musica al morir
        {
            StartCoroutine(FadeOutMusic(2f)); // 
            walkingSource.Stop();
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

        if (attackSound != null)
        {
            sfxSource.PlayOneShot(attackSound);
        }

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

    public void StopMusic()
    {
        if (musicSource != null && musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }
    private System.Collections.IEnumerator FadeOutMusic(float duration)
    {
        float startVolume = musicSource.volume;

        while (musicSource.volume > 0f)
        {
            musicSource.volume -= startVolume * Time.unscaledDeltaTime / duration;
            yield return null;
        }

        musicSource.Stop();
        musicSource.volume = startVolume; // opcional: resetea volumen para cuando reinicies el juego
    }

    public void RespawnPlayer()
    {
        transform.position = Respawn.position;
        musicSource.volume = 1f;
        musicSource.Play();
    }

   
}




