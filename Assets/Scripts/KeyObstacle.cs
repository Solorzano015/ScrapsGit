using UnityEngine;

public class KeyObstacle : MonoBehaviour
{
    public bool hasKey = false;

    [Header ("Sonidos")]
    public AudioClip KeySound;
    public AudioClip obstaclePassSound;
    public AudioSource KeyDoorSource;
    

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Key"))
        {
            if (KeyDoorSource != null && KeySound != null)
            {
                //AudioSource.PlayClipAtPoint(KeySound, transform.position);
                KeyDoorSource.PlayOneShot(KeySound);
                Debug.Log("Sono llave");
            }
            hasKey = true;
            Destroy(other.gameObject);

            Debug.Log("Llave Recogida");

        }                    


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ObstacleKey"))
        {
            if (hasKey == true)
            {
                if (KeyDoorSource != null && obstaclePassSound != null)
                {
                    //AudioSource.PlayClipAtPoint(obstaclePassSound, transform.position);
                    KeyDoorSource.PlayOneShot(obstaclePassSound);
                    Debug.Log("SonoPuerta");
                }
                Destroy(collision.gameObject);
                Debug.Log("Puertadesbloqueada");
            }
            else
            {
                Debug.Log("No tienes la llave");
            }
        }
        

    }
}
