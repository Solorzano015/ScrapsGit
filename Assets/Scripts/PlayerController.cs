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

    private Vector2 moveInput;
    public float normalGravity;
    public float AbGravity;

    public LayerMask groundMask;
    public Transform Respawn;
    public SpriteRenderer spriteRenderer;

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
        //moverse en el mundo
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();


        rb.velocity = new Vector3(moveInput.x * speed, rb.velocity.y, moveInput.y * speed);

        /*
        RaycastHit hit;
        if (Physics.Raycast(groundPoint.position, Vector3.down, out hit, .3f, groundMask))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        */
        isGrounded = Physics.Raycast(groundPoint.position, Vector3.down, groundDist, groundMask);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);


            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            //rb.velocity += new Vector3(0f, jumpForce, 0f);

        }
        //Manejar gravedad para planear o saltar solo
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

        //Hacer que se voltee el sprite

        if (moveInput.x != 0 && moveInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveInput.x != 0 && moveInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        //revisar si toca el suelo (no funcionaba salto)

        Debug.DrawRay(groundPoint.position, Vector3.down * groundDist, Color.red);
        Debug.Log("¿Está en el suelo? " + isGrounded);

        // asegurar que no se salga del mapa
        if (transform.position.y < -10f)
        {
            transform.position = new Vector3(0, 2, 0); // Reaparece en un punto seguro
        }

        




    }
    public void RespawnPlayer()
    {
        transform.position = Respawn.position;
    }


}



