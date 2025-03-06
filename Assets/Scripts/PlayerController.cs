using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float groundDist;

    public LayerMask groundMask;
    public Rigidbody rb;
    public SpriteRenderer SpriteRenderer;



    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {

       

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(x, 0, y).normalized;
        rb.velocity = new Vector3(direction.x * speed, rb.velocity.y * speed, direction.z * speed);
        //rb.AddForce = direction * speed;
        //rb.angularVelocity = direction * speed *Time.deltaTime;


        if (x != 0 && x < 0)
        {
            SpriteRenderer.flipX = true;
        }
        else if (x != 0 && x > 0)
        {
            SpriteRenderer.flipX = false;
        }
    }
}
