using UnityEngine;

public class ShowInfoUI : MonoBehaviour
{
    public GameObject infoUI1;
    public GameObject infoUI2;

    void Start()
    {
        infoUI1 = GameObject.Find("InfoUI1");
        infoUI2 = GameObject.Find("InfoUI2");

        if (infoUI1 != null) infoUI1.SetActive(false);
        if (infoUI2 != null) infoUI2.SetActive(false);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            if (infoUI1 != null) infoUI1.SetActive(true);
            if (infoUI2 != null) infoUI2.SetActive(true);
        }
    }

    

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (infoUI1 != null) infoUI1.SetActive(false);
            if (infoUI2 != null) infoUI2.SetActive(false);
        }
    }
}
