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
        RaycastHit hit;
        Vector3 castPos = transform.position;
        castPos.y += 1;
        if (Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, groundMask))
        {
            if (hit.collider != null)

            {
                Vector3 movePos = transform.position;
                movePos.y = hit.point.y + groundDist;
                transform.position = movePos;

            }

        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(x, 0, y);
        rb.linearVelocity = direction * speed;

        rb.angularVelocity = direction * speed;

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
