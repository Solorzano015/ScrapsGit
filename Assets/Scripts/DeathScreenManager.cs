using UnityEngine;

public class DeathScreenManager : MonoBehaviour
{
    
   public HealthControl healthControl;

   public void OnRetryButtonPressed()
   {
      healthControl.Respawn();  // Llama a la funci�n para reaparecer
   }
   
}
