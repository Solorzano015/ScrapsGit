using UnityEngine;

public class KeyObstacle : MonoBehaviour
{
    public bool hasKey = false;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Key"))
        {

            hasKey = true;
            Destroy(other.gameObject);
            Debug.Log("Llave Recogida");

        }                    


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ObstacleKey") && hasKey)
        {
            Destroy(collision.gameObject);
            Debug.Log("Puertadesbloqueada");
        }

    }
}
