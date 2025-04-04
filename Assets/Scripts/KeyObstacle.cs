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

        if (other.CompareTag("ObstacleKey") && hasKey)
        {
            Destroy(other.gameObject);
            Debug.Log("Puertadesbloqueada");
        }
        


    }
}
