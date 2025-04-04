using UnityEngine;
using UnityEngine.SceneManagement;

public class TapeRespawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        string scene = SceneManager.GetActiveScene().name;

        switch (scene)
        {
            case "Nivel1":
                transform.position = new Vector3(433f, 76f, 221f);
                break;

            case "Nivel2":
                transform.position = new Vector3(343f, 54f, 238f);
                break;
            case "Nivel3HUD":
                transform.position = new Vector3(491f, 139f, 137f);
                break;
        }

        

    }

    
}
