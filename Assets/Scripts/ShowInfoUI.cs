using UnityEngine;

public class ShowInfoUI : MonoBehaviour
{
    public GameObject InfoUIObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        InfoUIObject = GameObject.Find("UInewInfo");
        InfoUIObject.SetActive(false);

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            InfoUIObject.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            InfoUIObject.SetActive(false);
        }
    }
}
