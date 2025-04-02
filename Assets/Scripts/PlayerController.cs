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

        isGrounded = Physics.Raycast(groundPoint.position, Vector3.down, groundDist, groundMask);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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
        }
        else
        {
            rb.velocity += Vector3.down * normalGravity * Time.deltaTime;
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

        
    }

   

    void Animation()
    {
        if (moveInput.x != 0)
        {
            animator.SetBool("WalkingL", true);
        }
        else
        {
            animator.SetBool("WalkingL", false);
        }
        
    }

    public void RespawnPlayer()
    {
        transform.position = Respawn.position;
    }
}



