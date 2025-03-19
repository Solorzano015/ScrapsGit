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
    public LayerMask groundMask;
    public Transform Respawn;
    public SpriteRenderer spriteRenderer;


    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

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

        if (moveInput.x != 0 && moveInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveInput.x != 0 && moveInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }

        Debug.DrawRay(groundPoint.position, Vector3.down * groundDist, Color.red);
        Debug.Log("¿Está en el suelo? " + isGrounded);


        if (transform.position.y < -10f)
        {
            transform.position = new Vector3(0, 2, 0); // Reaparece en un punto seguro
        }


    }


}



