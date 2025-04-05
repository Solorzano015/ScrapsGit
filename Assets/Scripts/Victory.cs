using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public BossFinal boss; // Arrastra aquí el Boss desde el inspector

    private bool bossDefeated => boss == null || boss.enemyBHealth <= 0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && bossDefeated)
        {
            Debug.Log("¡Victoria! Has derrotado al jefe y alcanzado la zona final.");

            SceneManager.LoadScene("3erVideo");

            // O activar algún canvas:
            // winCanvas.SetActive(true);
        }
        else if (other.CompareTag("Player") && !bossDefeated)
        {
            Debug.Log("No puedes entrar hasta derrotar al jefe.");
        }
    }
}
