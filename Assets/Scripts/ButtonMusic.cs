using UnityEngine;

public class ButtonMusic : MonoBehaviour
{

    public AudioSource sound;
    public AudioClip clip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        sound = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    public void ClickAudioOn()
    {
        sound.PlayOneShot(clip);
        
    }
}
