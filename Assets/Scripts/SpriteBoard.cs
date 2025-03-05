using UnityEngine;

public class SpriteBoard : MonoBehaviour
{
    [SerializeField] bool freeseXZ = true;  
   
    private void LateUpdate()
    {
        
        if (freeseXZ)
        {
            transform.rotation = Quaternion.Euler(0f, Camera.main.transform.rotation.eulerAngles.y, 0f);
        }
        else
        {
            transform.rotation = Camera.main.transform.rotation;
        }



    }
}
